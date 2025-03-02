﻿using System;

namespace Simulator.DataObjects
{
    public interface IBaseDataObject
    {
        string Id { get; set; }

    }
    

    public class BaseDataObject : IBaseDataObject
    {
        public BaseDataObject() { Id = Guid.NewGuid().ToString(); }

        public string Id { get ; set ; }
    }
}
