using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(string messsage,T data):base(true,messsage,data)
        {

        }

        public SuccessDataResult(T data):base(true,data)
        {

        }

        public SuccessDataResult(string message) : base(true,message,default)
        {

        }

        public SuccessDataResult():base(true,default)
        {

        }
    }
}
