using BizHawk.Client.Common;
using SotnApi.Interfaces;
using System;

namespace SotnApi.Main
{
    public sealed class SotnApi : ISotnApi
    {
        private readonly IGameApi gameApi;
        private readonly IAlucardApi alucardApi;
        private readonly IEntityApi entityApi;
        private readonly IMapApi mapApi;
        public SotnApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException(nameof(memAPI)); }
            gameApi = new GameApi(memAPI);
            alucardApi = new AlucardApi(memAPI);
            entityApi = new EntityApi(memAPI);
            mapApi = new MapApi(memAPI);
        }

        public IGameApi GameApi
        {
            get
            {
                return this.gameApi;
            }
        }
        public IAlucardApi AlucardApi
        {
            get
            {
                return this.alucardApi;
            }
        }
        public IEntityApi EntityApi
        {
            get
            {
                return this.entityApi;
            }
        }
        public IMapApi MapApi
        {
            get
            {
                return this.mapApi;
            }
        }
    }
}
