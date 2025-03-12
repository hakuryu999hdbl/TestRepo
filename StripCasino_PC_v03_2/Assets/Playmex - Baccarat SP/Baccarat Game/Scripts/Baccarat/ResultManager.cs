﻿using UnityEngine;
using System.Collections.Generic;
namespace Baccarat_Game
{
    public class ResultManager : MonoBehaviour
    {

        public static ResultManager Instance { get; private set; }
        public WinSequence winHandler;

        public static bool betsEnabled = true;

        public static int roundCount = -1;

        public static float totalWin = 0;

        public delegate void voidEvent();
        public static event voidEvent onResult;

        private List<BetSpace> betSpaces = new List<BetSpace>();
        public Transform chipTrayPosition;

        private static int playerResult = 0, bankerResult = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void SetResult(int player, int banker)
        {
            totalWin = 0;
            playerResult = player;
            bankerResult = banker;

            foreach (BetSpace betSpace in betSpaces)
            {
                totalWin += betSpace.ResolveBet();
            }
            print("The total win is: " + totalWin);
            BalanceManager.ChangeBalance(totalWin);
            winHandler.ShowResult(totalWin);
            onResult();
        }

        public static Vector3 GetChipWinPosition()
        {
            return Instance.chipTrayPosition.position;
        }

        public static void RegisterBetSpace(BetSpace betSpace)
        {
            Instance.betSpaces.Add(betSpace);
        }

        public static bool IsTie()
        {
            return playerResult == bankerResult;
        }
        public static bool PlayerWon()
        {
            return playerResult > bankerResult;
        }
    }
}