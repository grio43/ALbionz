﻿// ------------------------------------------------------------------------------
//   <copyright from='2010' to='2015' company='THEHACKERWITHIN.COM'>
//     Copyright (c) TheHackerWithin.COM. All Rights Reserved.
//
//     Please look in the accompanying license.htm file for the license that
//     applies to this source code. (a copy can also be found at:
//     http://www.thehackerwithin.com/license.htm)
//   </copyright>
// -------------------------------------------------------------------------------

extern alias SC;

using EVESharpCore.Cache;
using EVESharpCore.Lookup;
using SC::SharedComponents.Py;
using SC::SharedComponents.EVE;
using System;
using System.Linq;

namespace EVESharpCore.Framework
{
    extern alias SC;

    public class DirectLoginRewardButton : DirectObject
    {
        #region Fields

        private readonly PyObject _pyBtn;

        #endregion Fields

        #region Constructors

        internal DirectLoginRewardButton(DirectEve directEve, PyObject pyBtn)
            : base(directEve)
        {
            _pyBtn = pyBtn;
        }

        #endregion Constructors

        #region Properties

        public string ButtonName { get; internal set; }
        public string Text { get; internal set; }
        public LoginRewardButtonType Type { get; internal set; }

        #endregion Properties

        #region Methods

        public bool Click()
        {
            if (DateTime.UtcNow < Time.Instance.LastWindowInteraction.AddSeconds(3))
                return false;

            if (DirectEve.ThreadedCall(_pyBtn.Attribute("OnClick")))
            {
                Time.Instance.LastWindowInteraction = DateTime.UtcNow;
                return true;
            }

            return false;
        }

        #endregion Methods
    }
}