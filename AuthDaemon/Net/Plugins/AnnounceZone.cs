﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDaemon.Net.Plugins
{
    public class AnnounceZone : Plugin
    {
        public override string Name
        {
            get
            {
                return "announcezone";
            }
        }

        public uint ZoneId;
        public uint Aid;
        public uint BlReset;
        public byte[] Ip1;
        public byte[] Ip2;
        public byte[] Ip3;
        public uint GetAuVersion;
        public uint Reserved;

        public override void Initialize()
        {
            Session.Handler.AddHandler(505, OnAnnounceZoneId);
            Session.Handler.AddHandler(523, OnAnnounceZoneId);
            Session.Handler.AddHandler(527, OnAnnounceZoneId);
        }
        private void OnAnnounceZoneId(object sender, PacketEventArgs e)
        {
            var packet = e.Packet;
            ZoneId = e.Packet.ZoneId;
            Aid = e.Packet.Aid;
            BlReset = e.Packet.BlReset;
            Ip1 = e.Packet.Ip1;
            Ip2 = e.Packet.Ip2;
            Ip3 = e.Packet.Ip3;
            GetAuVersion = e.Packet.Reserved1;
            Reserved = e.Packet.Reserved2;

            if (Enabled)
            {
                Log.Info("ZoneId: {0}, Aid: {1}, BlReset: {2}", ZoneId, Aid, BlReset);
            }
        }
    }
}
