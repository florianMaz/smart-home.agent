export interface Item {
    link: string;
    state: string;
    editable: boolean;
    type: Type;
    name: string;
    label: string;
    category: string;
    tags: Tag[];
    metadata?: { [key: string]: any; };
    groupNames: string[];
    transformedState?: TransformedState;
    members?: any[];
    groupType?: Type;
}

export enum Type {
    Color = "Color",
    Contact = "Contact",
    DateTime = "DateTime",
    Dimmer = "Dimmer",
    Group = "Group",
    Number = "Number",
    NumberAngle = "Number:Angle",
    Rollershutter = "Rollershutter",
    String = "String",
    Switch = "Switch",
}

export enum Tag {
    B6Qbj = "B6QBJ",
    U43Fr = "U43FR",
    U5Dwt = "U5DWT",
    Neiz0 = "NEIZ0",
    Xt6M1 = "XT6M1",
    Window = "Window",
    Basement = "Basement",
    Bathroom = "Bathroom",
    Bedroom = "Bedroom",
    Blinds = "Blinds",
    Building = "Building",
    Dev = "dev",
    Door = "Door",
    FirstFloor = "FirstFloor",
    Garage = "Garage",
    Garden = "Garden",
    GroundFloor = "GroundFloor",
    Humidity = "Humidity",
    Hvac = "HVAC",
    Kitchen = "Kitchen",
    Lighting = "Lighting",
    LivingRoom = "LivingRoom",
    MotionDetector = "MotionDetector",
    Outdoor = "Outdoor",
    Rollershutter = "Rollershutter",
    Room = "Room",
    Switch = "Switch",
    Switchable = "Switchable",
    Temperature = "Temperature",
    Terrace = "Terrace",
    Thermostat = "Thermostat",
}

export enum TransformedState {
    Clear = "clear",
    Closed = "closed",
    Detected = "detected",
    Open = "open",
    Unknown = "unknown",
}
