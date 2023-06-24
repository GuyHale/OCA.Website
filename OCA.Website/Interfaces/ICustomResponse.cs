﻿
namespace OCA.Website.Interfaces
{
    public interface ICustomResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
