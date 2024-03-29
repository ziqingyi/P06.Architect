﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.Utility.DbContextExtension;

namespace P03.DotNetCoreMVC.Utility.Interface
{
    public interface ICustomDbContextFactory
    {
        DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead);
    }
}
