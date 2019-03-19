using System.Collections.Generic;
using AutoMapper;
using BlackJack.BusinessLogic.DTO;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        public PlayerService(IDbWorker dbWorker) : base(dbWorker)
        {
        }

        public IEnumerable<PlayerDTO> GetBotList()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Player, PlayerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Player>, List<PlayerDTO>>(_dbWorker.Players.Find(player => player.IsBot));
        }

        public IEnumerable<PlayerDTO> GetPlayableList()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Player, PlayerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Player>, List<PlayerDTO>>(_dbWorker.Players.Find(player => !player.IsBot));
        }

        public void MakePlayer(PlayerDTO playerDto)
        {
            _dbWorker.Players.Create(new Player
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                IsBot = playerDto.IsBot
            });

            _dbWorker.Save();
        }
    }
}
