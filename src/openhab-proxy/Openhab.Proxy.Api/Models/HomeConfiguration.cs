using System;
using System.Collections.Generic;

namespace Openhab.Proxy.Api.Models
{
    /// <summary>
    /// Home configuration including zones, rooms and devices
    /// </summary>
    public class HomeConfiguration
    {
        /// <summary>
        /// Home id in openhab
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Access Token UUID
        /// </summary>
        public Guid Uuid { get; set; }
        /// <summary>
        /// Namespace value for dialogflow (internal)
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Home Zones
        /// </summary>
        public IEnumerable<Zone> Zones { get; set; }
    }

    /// <summary>
    /// Represents a specific zone (e.g. GroundFloor, Outside)
    /// </summary>
    public class Zone
    {
        /// <summary>
        /// Zone id in openhab
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Zone sub name in openhab
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Zone description/label
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Zone rooms
        /// </summary>
        public IEnumerable<Room> Rooms { get; set; }
    }

    /// <summary>
    /// Represents a specific room (e.g. Office, LivingRoom)
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Room id in openhab
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Room sub name in openhab
        /// (room value in dialogflow metadata)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Room description/label
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Room devices
        /// </summary>
        public IEnumerable<Device> Devices { get; set; }
    }

    /// <summary>
    ///  Represents a specific device (e.g. Blind, Door)
    /// </summary>
    public class Device
    {
        /// <summary>
        /// device id in openhab (Item Id)
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Device description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Device room
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// Device zone
        /// </summary>
        public string Zone { get; set; }
        /// <summary>
        /// Device type exposed for dialogflow
        /// (type value in dialogflow metadata)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Internal openhab device type
        /// </summary>
        public string OpenhabType { get; set; }
    }

}
