﻿using BelotCardGame.Services.Constants;
using BelotCardGame.Services.Contracts;

namespace BelotCardGame.Services.Services
{
    public class Engine : IEngine
    {
        private readonly IComputerService computerService;
        private readonly IPlayerService playerService;
        private readonly IGameService dealerService;
        private readonly Values values;
        public Engine(IComputerService computerService, IPlayerService playerService, IGameService dealerService
            , Values values)
        {
            this.computerService = computerService;
            this.playerService = playerService;
            this.dealerService = dealerService;
            this.values = values;
        }

        public void Run()
        {
            dealerService.DrawCards(1, 10);
            playerService.ShowHand();
            string playerChoice = playerService.ChooseGameType(values.playerGameType);
            string computerChoice = computerService.ChooseTypeOfGame(playerChoice, values.computerGameType);
            string choosenGameType = dealerService.CompareGameTypes(computerChoice, playerChoice, values.playerGameType);
            dealerService.DrawCards(1, 6);
            playerService.ShowHand();
            dealerService.Play(choosenGameType, playerService.ReturnHand(), computerService.ShowHand());
        }
    }
}
