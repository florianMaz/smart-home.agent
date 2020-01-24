import express from 'express';
import * as bodyParser from 'body-parser';
import { dialogflow, actionssdk, Image, Carousel, BasicCard, Button, SimpleResponse } from 'actions-on-google';
import { OpenhabClient } from '../src/openhabClient'
import { Item } from './models/openhab/item.model';
import { Device } from "./models/device.model";
import { Room } from "./models/room.model";
import { Zone } from './models/zone.model';

const openhabClient = new OpenhabClient('https://openhabproxyapi-dev-as.azurewebsites.net', '4285833b-753e-4c29-a38b-a280da6250fa');

const server = express();
const assistant = dialogflow({ debug: false });

server.set('port', process.env.PORT || 8080);
server.use(bodyParser.json({ type: 'application/json' }));

assistant.intent('demo.smarthome.device.state', async (conv, { room, deviceType, all }) => {
    let _device: Device;
    let _room: Room;
    let _openhabItem: Item;

    // fetch configurations 
    await openhabClient.getAllDevices()
        .then(x => _device = x.find(d => d.room === room && d.type == deviceType));
    await openhabClient.getAllRooms()
        .then(x => _room = x.find(r => r.name === room));

    console.log(_device);
    // respond with appropriate sentense if device is not found
    if (!_device) {
        conv.close(`Sorry mate, couldn't find any device of type ${deviceType} in ${_room.description}`);
        return;
    }

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
    if (!_device) {
        conv.close(`Sorry, couldn't find any device of type ${deviceType} in ${_room.description}`);
        return;
    }

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

assistant.intent('demo.smarthome.zone.command', async (conv, { zone, deviceType, command, value, all }) => {
    let _devices: Device[];
    let _zone: Zone;

    // fetch configurations 
    if (!zone && all === 'true') {
        await openhabClient.getAllDevices()
            .then(x => _devices = x.filter(d => d.type == deviceType));
        _zone = {
            id: '//Todo',
            description: 'Home',
            name: 'Home'
        };
    } else {
        await openhabClient.getAllDevices()
            .then(x => _devices = x.filter(d => d.zone === zone && d.type == deviceType));
        await openhabClient.getAllZones()
            .then(x => _zone = x.find(r => r.name === zone));
    }

    // respond with appropriate sentense if device list is undefined or empty
    if (!_devices || _devices.length === 0) {
        conv.close(`Sorry, couldn't find any device of type ${deviceType} in ${_zone.description}`);
        return;
    }

    // here, al least one device is found
    let responseMessage: string = `Zone: ${zone}  \n`;
    let updatedState: string;

    await Promise.all(_devices.map(async _device => {
        let _openhabItem: Item;
        // get the initial state
        await openhabClient.getItem(_device.id)
            .then(x => _openhabItem = x);
        let initialState = isNaN(+_openhabItem.state) ? _openhabItem.state : (Math.round(+_openhabItem.state * 100) / 100).toFixed(0);

        // send command |or| update state
        await openhabClient.sendCommand(_openhabItem.name, (command === undefined || command === "") ? value : command)
            .then(async _ => {
                // re-fetch updated state  
                await openhabClient.getItem(_device.id).then(x => updatedState = x.state);
            })
        responseMessage.concat(`=> ${deviceType} has benn updated from ${initialState} to ${updatedState}  \n`);
        responseMessage = responseMessage.concat(`=> ${deviceType} has benn updated from ${initialState} to ${updatedState}  \n`);

    }));
    // close conversation
    conv.ask(new SimpleResponse({
        text: responseMessage,
        speech: 'Are you talking to me ?'
    }));
});

server.post('/webhook', assistant);
server.listen(server.get('port'), function () {
    console.log('Express server started on port', server.get('port'));
});
