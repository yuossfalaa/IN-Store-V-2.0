﻿using System.Globalization;

namespace INStore.State.Registers
{
    public interface IRegister
    {
        CultureInfo GetLanguage();
        void SetLanguage(CultureInfo Culture);
    }
}