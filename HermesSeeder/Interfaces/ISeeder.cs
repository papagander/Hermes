using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesSeeder.Interfaces;

public interface ISeeder 
    : IDisposable
{
    void Seed();
}