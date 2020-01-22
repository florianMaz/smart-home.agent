import express from 'express';
import * as bodyParser from 'body-parser';
import { dialogflow, actionssdk, Image, Carousel, BasicCard, Button } from 'actions-on-google';
import { OpenhabClient } from '../src/openhabClient'
import { Item } from './models/openhab/item.model';
import { Device } from "./models/device.model";
import { Room } from "./models/room.model";

const openhabClient = new OpenhabClient('https://openhabproxyapi-dev-as.azurewebsites.net', '<acess-token>');

const server = express();
const assistant = dialogflow({ debug: false });

server.set('port', process.env.PORT || 8080);
server.use(bodyParser.json({ type: 'application/json' }));

assistant.intent('demo.smarthome.device.state.check', async (conv, { room, deviceType, all }) => {
    let _device: Device;
    let _room: Room;
    let _openhabItem: Item;

    // fetch configurations 
    await openhabClient.getAllDevices()
        .then(x => _device = x.find(d => d.room === room && d.type == deviceType));
    await openhabClient.getAllRooms()
        .then(x => _room = x.find(r => r.name === room));

    // respond with appropriate sentense if device is not found
    if (!_device)
        conv.close(`Sorry, couldn't find any device of type ${deviceType} in ${_room.description}`);

    // here device is found, get the state
    await openhabClient.getItem(_device.id)
        .then(x => _openhabItem = x);
    // transform the state
    let state = isNaN(+_openhabItem.state) ? _openhabItem.state : (Math.round(+_openhabItem.state * 100) / 100).toFixed(0);
    // close conversation
    conv.close(`${deviceType} is ${state} in ${_room.description}`);
});

assistant.intent('demo.smarthome.device.command', async (conv, { room, deviceType, command, value }) => {
    let _device: Device;
    let _room: Room;
    let _openhabItem: Item;

    // fetch configurations 
    await openhabClient.getAllDevices()
        .then(x => _device = x.find(d => d.room === room && d.type == deviceType));
    await openhabClient.getAllRooms()
        .then(x => _room = x.find(r => r.name === room));

    // respond with appropriate sentense if device is not found
    if (!_device)
        conv.close(`Sorry, couldn't find any device of type ${deviceType} in ${_room.description}`);

    // here device is found, get the initial state
    let updatedState: string;

    await openhabClient.getItem(_device.id)
        .then(x => _openhabItem = x);
    let initialState = isNaN(+_openhabItem.state) ? _openhabItem.state : (Math.round(+_openhabItem.state * 100) / 100).toFixed(0);
    // send command |or| update state
    await openhabClient.sendCommand(_openhabItem.name, (command === undefined || command === "") ? value : command)
        .then(async _ => {
            // re-fetch updated state  
            await openhabClient.getItem(_device.id).then(x => updatedState = x.state);
        })
    // close conversation
    conv.close(`${deviceType} in ${_room.description} has benn updated from ${initialState} to ${updatedState}`);
});

server.post('/webhook', assistant);
server.listen(server.get('port'), function () {
    console.log('Express server started on port', server.get('port'));
});
