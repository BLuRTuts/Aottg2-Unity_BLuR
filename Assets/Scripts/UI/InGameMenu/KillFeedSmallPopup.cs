﻿using UnityEngine;
using UnityEngine.UI;
using GameProgress;
using ApplicationManagers;
using Utility;

namespace UI
{
    class KillFeedSmallPopup: BasePopup
    {
        protected override string Title => string.Empty;
        protected override float Width => 0f;
        protected override float Height => 0f;
        protected override float TopBarHeight => 0f;
        protected override float BottomBarHeight => 0f;
        protected override PopupAnimation PopupAnimationType => PopupAnimation.Fade;
        protected override float AnimationTime => 0.2f;
        private Text _leftLabel;
        private Text _rightLabel;
        private Text _scoreLabel;
        private Text _backgroundLabel;
        public float TimeLeft;
        public string Killer;
        public string Victim;
        public int Score;
        public string Weapon;
        private RawImage _image;

        public override void Setup(BasePanel parent = null)
        {
            base.Setup(parent);
            var go = ElementFactory.InstantiateAndBind(transform, "Prefabs/InGame/KillFeedLabelSmall");
            _leftLabel = go.transform.Find("LeftLabel").GetComponent<Text>();
            _rightLabel = go.transform.Find("RightLabel").GetComponent<Text>();
            _scoreLabel = go.transform.Find("ScoreLabel").GetComponent<Text>();
            _backgroundLabel = go.transform.Find("ScoreLabel/BackgroundLabel").GetComponent<Text>();
            _image = go.GetComponent<RawImage>();
        }

        public void ShowImmediate(string killer, string victim, int score, string weapon, float timeLeft)
        {
            Killer = killer;
            Victim = victim;
            Score = score;
            Weapon = weapon;
            _image.texture = (Texture2D)ResourceManager.LoadAsset(ResourcePaths.UI, GetWeaponIcon(weapon), true);
            _leftLabel.text = killer;
            _rightLabel.text = victim;
            _scoreLabel.text = score.ToString();
            _backgroundLabel.text = score.ToString();
            if (score >= 1000)
                _backgroundLabel.color = Color.red;
            else
                _backgroundLabel.color = Color.white;
            IsActive = false;
            TimeLeft = timeLeft;
            ShowImmediate();
        }

        private string GetWeaponIcon(string weapon)
        {
            if (weapon == "AHSS" || weapon == "APG")
                return "Icons/Game/AHSSIcon";
            else if (weapon == "Thunderspear")
                return "Icons/Game/ThunderspearIcon";
            else if (weapon == "Stun" || weapon == "Eat" || weapon == "Titan")
                return "Icons/Quests/Skull2Icon";
            return "Icons/Game/KillFeedIcon";
        }
    }
}
