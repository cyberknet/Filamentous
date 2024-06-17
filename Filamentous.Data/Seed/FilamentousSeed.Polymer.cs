using Filamentous.Data.Entities;
using JumpStart.Data.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal partial class FilamentousSeed
{
    private SequentialGuid _polymerGuid = new("D9A3F45C-81AE-4B86-B477-040000000000");
    private Dictionary<Guid, Polymer> _polymers = new();

    // DO NOT REORDER or insert new values in the middle of the list!
    private Guid _polymerIdPLA;
    private Guid _polymerIdPETG;
    private Guid _polymerIdASA;
    private Guid _polymerIdABS;
    private Guid _polymerIdTPU;
    private Guid _polymerIdPC;
    private Guid _polymerIdPVB;
    private Guid _polymerIdCoPA;
    private Guid _polymerIdPA6CF;
    private Guid _polymerIdPA6GF;
    private Guid _polymerIdPA12CF;
    private Guid _polymerIdPVA;
    private Guid _polymerIdPCL;
    private Guid _polymerIdPPS;
    private Guid _polymerIdPS;
    private Guid _polymerIdPSU;
    private Guid _polymerIdPPSU;
    private Guid _polymerIdPPA;
    private Guid _polymerIdPEEK;
    private Guid _polymerIdPEKK;
    private Guid _polymerIdOther;
    private Guid _polymerIdPA11CF;

    private void InitializePolymers()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _polymerIdPLA = _polymerGuid.Next();
        _polymerIdPETG = _polymerGuid.Next();
        _polymerIdASA = _polymerGuid.Next();
        _polymerIdABS = _polymerGuid.Next();
        _polymerIdTPU = _polymerGuid.Next();
        _polymerIdPC = _polymerGuid.Next();
        _polymerIdPVB = _polymerGuid.Next();
        _polymerIdCoPA = _polymerGuid.Next();
        _polymerIdPA6CF = _polymerGuid.Next();
        _polymerIdPA6GF = _polymerGuid.Next();
        _polymerIdPA12CF = _polymerGuid.Next();
        _polymerIdPVA = _polymerGuid.Next();
        _polymerIdPCL = _polymerGuid.Next();
        _polymerIdPPS = _polymerGuid.Next();
        _polymerIdPS = _polymerGuid.Next();
        _polymerIdPSU = _polymerGuid.Next();
        _polymerIdPPSU = _polymerGuid.Next();
        _polymerIdPPA = _polymerGuid.Next();
        _polymerIdPEEK = _polymerGuid.Next();
        _polymerIdPEKK = _polymerGuid.Next();
        _polymerIdOther = _polymerGuid.Next();
        _polymerIdPA11CF = _polymerGuid.Next();
}
    private void Polymers(ModelBuilder modelBuilder)
    {
        MakePolymer(_polymerIdPLA, "PLA");
        MakePolymer(_polymerIdPETG, "PETG");
        MakePolymer(_polymerIdASA, "ASA");
        MakePolymer(_polymerIdABS, "ABS");
        MakePolymer(_polymerIdTPU, "TPU");
        MakePolymer(_polymerIdPC, "PC");
        MakePolymer(_polymerIdPVB, "PVB");
        MakePolymer(_polymerIdCoPA, "CoPA");
        MakePolymer(_polymerIdPA6CF, "PA6-CF");
        MakePolymer(_polymerIdPA6GF, "PA6-GF");
        MakePolymer(_polymerIdPA12CF, "PA12-CF");
        MakePolymer(_polymerIdPVA, "PVA");
        MakePolymer(_polymerIdPCL, "PCL");
        MakePolymer(_polymerIdPPS, "PPS");
        MakePolymer(_polymerIdPS, "PS");
        MakePolymer(_polymerIdPSU, "PSU");
        MakePolymer(_polymerIdPPSU, "PPSU");
        MakePolymer(_polymerIdPPA, "PPA");
        MakePolymer(_polymerIdPEEK, "PEEK");
        MakePolymer(_polymerIdPEKK, "PEKK");
        MakePolymer(_polymerIdOther, "Other");
        MakePolymer(_polymerIdPA11CF, "PA11-CF");

        Console.WriteLine($" * Entity Polymer has {_polymers.Keys.Count} rows in seed data.");
        modelBuilder.Entity<Polymer>().HasData(_polymers.Values.ToArray());
    }
    private void MakePolymer(Guid id, string name)
    {
        var polymer = new Polymer
        {
            Id = id,
            Name = name,
            CreatedById = _userAdminId.ToString(),
            ConcurrencyStamp = id
        };

        try
        {
            if (!_polymers.ContainsKey(polymer.Id))
                _polymers.Add(polymer.Id, polymer);
            //else
            //    Console.WriteLine($"Using existing Polymer {name} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Could not create Polymer {name} with id {id}: {ex.Message}");
        }
    }
}
