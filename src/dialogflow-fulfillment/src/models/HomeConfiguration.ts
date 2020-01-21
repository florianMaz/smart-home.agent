export interface HomeConfiguration {
    id: string;
    uuid: string;
    token: string;
    zones: ZoneElement[];
}

export interface ZoneElement {
    id: string;
    name: string;
    description: string;
    rooms?: ZoneElement[];
    devices?: Device[];
}

export interface Device {
    id: string;
    description: string;
    room: string;
    zone: ZoneEnum;
    type: string;
    openhabType: OpenhabType;
}

export enum OpenhabType {
    Color = "Color",
    Contact = "Contact",
    Dimmer = "Dimmer",
    Number = "Number",
    Rollershutter = "Rollershutter",
    Switch = "Switch",
}

export enum ZoneEnum {
    Cellar = "Cellar",
    GroundFloor = "GroundFloor",
    Outside = "Outside",
}