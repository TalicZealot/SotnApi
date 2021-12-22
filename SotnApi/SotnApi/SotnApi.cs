using BizHawk.Client.Common;
using SotnApi.Interfaces;
using System;

namespace SotnApi.Main
{
    public class SotnApi : ISotnApi
    {
        private readonly IGameApi gameApi;
        private readonly IAlucardApi alucardApi;
        private readonly IActorApi actorApi;
        private readonly IRenderingApi renderingApi;
        public SotnApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException(nameof(memAPI)); }
            gameApi = new GameApi(memAPI);
            alucardApi = new AlucardApi(memAPI);
            actorApi = new ActorApi(memAPI);
            renderingApi = new RenderingApi(memAPI);
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
        public IActorApi ActorApi
        {
            get
            {
                return this.actorApi;
            }
        }
        public IRenderingApi RenderingApi
        {
            get
            {
                return this.renderingApi;
            }
        }
    }
}
