using Filamentous.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal class FilamentousSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        IdentityUsers(modelBuilder);
        ApplicationRoles(modelBuilder);
        Polymers(modelBuilder);
        Brands(modelBuilder);
        //ProductLines(modelBuilder);
    }

    #region User
    private static Guid _userAdminId = Guid.Parse("D9A3F45C-81AE-4B86-B477-020000000001");
    private static IdentityUser _userAdmin = new()
    {
        Id = _userAdminId.ToString().ToUpper(),
        UserName = "scott@blomfield.us",
        NormalizedUserName = "SCOTT@BLOMFIELD.US",
        Email = "scott@blomfield.us",
        NormalizedEmail = "SCOTT@BLOMFIELD.US",
        EmailConfirmed = true,
        ConcurrencyStamp = _userAdminId.ToString().ToUpper(),
        PasswordHash = "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw==" // hashed version of "password"
    };
    private static void IdentityUsers(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityUser>()
            .HasData(_userAdmin);
    }
    #endregion

    #region Role
    private static Guid _roleAdminId = Guid.Parse("D9A3F45C-81AE-4B86-B477-010000000001");
    private static IdentityRole _roleAdmin = new()
    {
        Id = _roleAdminId.ToString().ToUpper(),
        Name = "Administrator",
        NormalizedName = "ADMINISTRATOR",
        ConcurrencyStamp = _roleAdminId.ToString().ToUpper()
    };

    private static void ApplicationRoles(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityRole>()
            .HasData(_roleAdmin);
    }
    #endregion

    #region Brand
    private static Guid _brandIdPrusament = Guid.Parse("D9A3F45C-81AE-4B86-B477-030000000001");
    private static Guid _brandIdPolymaker = Guid.Parse("D9A3F45C-81AE-4B86-B477-030000000002");
    private static Brand _brandPrusament = new ()
    {
        Id = _brandIdPrusament,
        Name = "Prusament",
        //Url = new Uri("https://prusa3d.com/"),
        ConcurrencyStamp = _brandIdPrusament,
        CreatedById = _userAdminId.ToString()
    };
    private static Brand _brandPolymaker = new()
    {
        Id = _brandIdPolymaker,
        Name = "Prusament",
        //Url = new Uri("https://us.polymaker.com/"),
        ConcurrencyStamp = _brandIdPolymaker,
        CreatedById = _userAdminId.ToString()
    };
    private static void Brands(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>()
            .HasData(_brandPrusament, _brandPolymaker);
    }
    #endregion

    #region Polymers
    private static Guid _polymerIdPLA     = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000001");
    private static Guid _polymerIdPETG    = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000002");
    private static Guid _polymerIdASA     = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000003");
    private static Guid _polymerIdABS = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000004");
    private static Guid _polymerIdTPU = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000005");
    private static Guid _polymerIdPC = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000006");
    private static Guid _polymerIdPVB = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000007");
    private static Guid _polymerIdCoPA = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000008");
    private static Guid _polymerIdPA6CF = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000009");
    private static Guid _polymerIdPA6GF = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000010");
    private static Guid _polymerIdPA12CF = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000011");
    private static Guid _polymerIdPVA = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000012");
    private static Guid _polymerIdPCL = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000013");
    private static Guid _polymerIdPPS  = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000014");
    private static Guid _polymerIdPS   = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000015");
    private static Guid _polymerIdPSU  = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000016");
    private static Guid _polymerIdPPSU = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000017");
    private static Guid _polymerIdPPA  = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000018");
    private static Guid _polymerIdPEEK = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000019");
    private static Guid _polymerIdPEKK = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000020");
    private static Guid _polymerIdOther = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000021");
    private static Guid _polymerIdPA11CF = Guid.Parse("D9A3F45C-81AE-4B86-B477-040000000022");

    private static Polymer _polymerPla = MakePolymer(_polymerIdPLA, "PLA");
    private static Polymer _polymerPetg = MakePolymer(_polymerIdPETG, "PETG");
    private static Polymer _polymerAsa = MakePolymer(_polymerIdASA, "ASA");
    private static Polymer _polymerAbs = MakePolymer(_polymerIdABS, "ABS");
    private static Polymer _polymerTpu = MakePolymer(_polymerIdTPU, "TPU");
    private static Polymer _polymerPc = MakePolymer(_polymerIdPC, "PC");
    private static Polymer _polymerPvb = MakePolymer(_polymerIdPVB, "PVB");
    private static Polymer _polymerCoPA = MakePolymer(_polymerIdCoPA, "CoPA");
    private static Polymer _polymerPa6CF = MakePolymer(_polymerIdPA6CF, "PA6-CF");
    private static Polymer _polymerPa6GF = MakePolymer(_polymerIdPA6GF, "PA6-GF");
    private static Polymer _polymerPa12CF = MakePolymer(_polymerIdPA12CF, "PA12-CF");
    private static Polymer _polymerPva = MakePolymer(_polymerIdPVA, "PVA");
    private static Polymer _polymerPcl = MakePolymer(_polymerIdPCL, "PCL");
    private static Polymer _polymerPps  = MakePolymer(_polymerIdPPS ,"PPS");
    private static Polymer _polymerPs   = MakePolymer(_polymerIdPS  ,"PS");
    private static Polymer _polymerPsu  = MakePolymer(_polymerIdPSU ,"PSU");
    private static Polymer _polymerPpsu = MakePolymer(_polymerIdPPSU,"PPSU");
    private static Polymer _polymerPpa  = MakePolymer(_polymerIdPPA ,"PPA");
    private static Polymer _polymerPeek = MakePolymer(_polymerIdPEEK,"PEEK");
    private static Polymer _polymerPekk = MakePolymer(_polymerIdPEKK,"PEKK");
    private static Polymer _polymerOther = MakePolymer(_polymerIdOther, "Other");
    private static Polymer _polymerPa11CF = MakePolymer(_polymerIdPA11CF, "PA11-CF");

    private static void Polymers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Polymer>()
            .HasData(
                _polymerPla,
                _polymerPetg,
                _polymerAsa,
                _polymerAbs,
                _polymerTpu,
                _polymerPc,
                _polymerPvb,
                _polymerCoPA,
                _polymerPa6CF,
                _polymerPa6GF,
                _polymerPa12CF,
                _polymerPva,
                _polymerPcl,
                _polymerPps,
                _polymerPs,
                _polymerPsu,
                _polymerPpsu,
                _polymerPpa,
                _polymerPeek,
                _polymerPekk,
                _polymerOther
            );
    }    
    private static Polymer MakePolymer(Guid id, string name) => 
        new Polymer
        { 
            Id=id, 
            Name=name, 
            CreatedById= _userAdminId.ToString(),
            ConcurrencyStamp =id 
        };
    #endregion

    #region ProductLines

    //#region Polymaker

    //#region PLA
    //#region PolyLite PLA
    //private static Guid _productLineIdPolyLitePla           = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000001");
    //private static Guid _productLineIdPolyLiteSilkPla       = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000002");
    //private static Guid _productLineIdPolyLiteDualSilkPla   = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000003");
    //private static Guid _productLineIdPolyLiteGalaxyPla     = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000004");
    //private static Guid _productLineIdPolyLiteStarlightPla  = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000005");
    //private static Guid _productLineIdPolyLiteLuminousPla   = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000006");
    //private static Guid _productLineIdPolyLiteGlowPla       = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000007");
    //private static Guid _productLineIdPolyLiteTempPla       = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000008");
    //private static Guid _productLineIdPolyLiteUVPla         = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000009");
    //#endregion

    //#region PolyTerra
    //private static Guid _productLineIdPolyTerraMatte             = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000010");
    //private static Guid _productLineIdPolyTerraDualMatte         = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000011");
    //private static Guid _productLineIdPolyTerraGradientMatte     = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000012");
    //private static Guid _productLineIdPolyTerraDualGradientMatte = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000013");
    //private static Guid _productLineIdPolyTerraMarble            = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000014");
    //private static Guid _productLineIdPolyTerraSatin             = Guid.Parse("D9A3F45C-81AE-4B86-B477-050000000015");
    //#endregion

    //#region Polysonic
    //private static Guid _productLineIdPolySonicPla    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000016");
    //private static Guid _productLineIdPolySonicPlaPro = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000017");
    //#endregion

    //#region PolyLite Pro/Max
    //private static Guid _productLineIdPolyLitePlaPro         = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000018");
    //private static Guid _productLineIdPolyLiteMetallicPlaPro = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000019");
    //private static Guid _productLineIdPolyMaxPla             = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000020");
    //#endregion

    //#region Other PLA
    //private static Guid _productLineIdSeasonalPacksPla = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000021");
    //private static Guid _productLineIdPolyLiteCosPla   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000022");
    //private static Guid _productLineIdLightWeightPla   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000023");
    //private static Guid _productLineIdCarbonFiberPla   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000024");
    //private static Guid _productLineIdPolyWoodPla      = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000025");
    //private static Guid _productLineIdDraftPla         = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000026");
    //private static Guid _productLineIdMattePla         = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000027");
    //#endregion
    //#endregion

    //#region ABS
    //private static Guid _productLineIdPolyLiteAbs         = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000028");
    //private static Guid _productLineIdPolyLiteMetallicAbs = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //private static Guid _productLineIdPolyLiteGalaxyAbs   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //private static Guid _productLineIdPolyLiteNeonAbs     = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //#endregion

    //#region ASA
    //private static Guid _productLineIdPolyLiteAsa       = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //private static Guid _productLineIdPolyLiteGalaxyAsa = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //#endregion

    //#region PETG
    //private static Guid _productLineIdPolyLitePetg            = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000029");
    //private static Guid _productLineIdPolyLiteTranslucentPetg = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000030");
    //private static Guid _productLineIdPolyMaxPetg             = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000031");
    //private static Guid _productLineIdPolyMaxPetgEsd          = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000032");
    //#endregion

    //#region TPU
    //private static Guid _productLineIdPolyMaxTpu90   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000033");
    //private static Guid _productLineIdPolyMaxTpu95   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000034");
    //private static Guid _productLineIdPolyMaxTpu95HF = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000035");
    //#endregion

    //#region PC
    //private static Guid _productLineIdPolyLitePC   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000036");
    //private static Guid _productLineIdPolyMaxPC    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000037");
    //private static Guid _productLineIdPolyMaxPCFR  = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000038");
    //private static Guid _productLineIdPolyMaxPCABS = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000039");
    //private static Guid _productLineIdPolyMaxPCPBT = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000040");
    //#endregion

    //#region Nylon
    //private static Guid _productLineIdPolyMideCoPA    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000041");
    //private static Guid _productLineIdPolyMidePA6GF   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000042");
    //private static Guid _productLineIdPolyMidePA6CF   = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000043");
    //private static Guid _productLineIdPolyMidePA612CF = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000044");
    //private static Guid _productLineIdPolyMidePA12CF  = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000045");
    //#endregion

    //#region Other
    //private static Guid _productLineIdPolySmooth      = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000046");
    //private static Guid _productLineIdPolyCast        = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000047");
    //private static Guid _productLineIdPolySupportPla  = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000048");
    //private static Guid _productLineIdPolySupportPa12 = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000049");
    //private static Guid _productLineIdPolyDissolve    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000050");
    //#endregion

    //#endregion

    //#region Prusament
    //private static Guid _productLineIdPrusamentPla     = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000051");
    //private static Guid _productLineIdPrusamentRPla    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000052");
    //private static Guid _productLineIdPrusamentPetg    = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000053");
    //private static Guid _productLineIdPrusamentPcBlend = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000054");
    //private static Guid _productLineIdPrusamentPvb     = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000055");
    //private static Guid _productLineIdPrusamentAsa     = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000056");
    //private static Guid _productLineIdPrusamentPa11Cf  = Guid.Parse("D9A3F45C-81AE-4B86-B477-05000000057");
    //#endregion

    //private static Dictionary<Guid, ProductLine> _productLines = new ();

    //private static void ProductLines(ModelBuilder modelBuilder)
    //{
    //    #region Polymaker
    //    #region PLA
    //    #region PolyLite
    //    MakeProductLine(_productLineIdPolyLitePla, "PolyLite PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteDualSilkPla, "PolyLite Silk PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteDualSilkPla, "PolyLite Dual Silk PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteGalaxyPla, "PolyLite Galaxy PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteStarlightPla, "PolyLite Starlight PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteLuminousPla, "PolyLite Luminous PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteGlowPla, "PolyLite Glow PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteTempPla, "PolyLite Temperature Color Changing PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteUVPla, "PolyLite UV Color Changing PLA", _polymerIdPLA);
    //    #endregion

    //    #region PolyTerra
    //    MakeProductLine(_productLineIdPolyTerraMatte, "PolyTerra Matte PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyTerraDualMatte, "PolyTerra Dual Matte PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyTerraGradientMatte, "PolyTerra Gradient Matte PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyTerraDualGradientMatte, "PolyTerra Dual Gradient Matte PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyTerraMarble, "PolyTerra Marble PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyTerraSatin, "PolyTerra Satin PLA", _polymerIdPLA);
    //    #endregion

    //    #region High Speed
    //    MakeProductLine(_productLineIdPolySonicPla, "PolySonic PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolySonicPlaPro, "PolySonic PLA Pro", _polymerIdPLA);
    //    #endregion

    //    #region PolyLite Pro/Max
    //    MakeProductLine(_productLineIdPolyLitePlaPro, "PolyLite PLA Pro", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteMetallicPlaPro, "PolyLite Metallic PLA Pro", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyMaxPla, "PolyMax PLA", _polymerIdPLA);
    //    #endregion

    //    #region Other
    //    MakeProductLine(_productLineIdSeasonalPacksPla, "Seasonal Packs PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyLiteCosPla, "PolyLite CosPLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdLightWeightPla, "Light Weight PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdCarbonFiberPla, "Carbon Fiber PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPolyWoodPla, "PolyWood PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdDraftPla, "Draft PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdMattePla, "Matte PLA", _polymerIdPLA);
    //    #endregion
    //    #endregion

    //    #region ABS
    //    MakeProductLine(_productLineIdPolyLiteAbs, "PolyLite ABS", _polymerIdABS);
    //    MakeProductLine(_productLineIdPolyLiteMetallicAbs, "PolyLite Metallic ABS", _polymerIdABS);
    //    MakeProductLine(_productLineIdPolyLiteGalaxyAbs, "PolyLite Galaxy ABS", _polymerIdABS);
    //    MakeProductLine(_productLineIdPolyLiteNeonAbs, "PolyLite Neon ABS", _polymerIdABS);
    //    #endregion

    //    #region ASA
    //    MakeProductLine(_productLineIdPolyLiteAsa, "PolyLite ASA", _polymerIdASA);
    //    MakeProductLine(_productLineIdPolyLiteGalaxyAsa, "PolyLite Galaxy ASA", _polymerIdASA);
    //    #endregion

    //    #region PETG
    //    MakeProductLine(_productLineIdPolyLitePetg, "PolyLite PETG", _polymerIdPETG);
    //    MakeProductLine(_productLineIdPolyLiteTranslucentPetg, "PolyLite Translucent PETG", _polymerIdPETG);
    //    MakeProductLine(_productLineIdPolyMaxPetg, "PolyMax PETG", _polymerIdPETG);
    //    MakeProductLine(_productLineIdPolyMaxPetgEsd, "PolyMax PETG-ESD", _polymerIdPETG);
    //    #endregion

    //    #region TPU
    //    MakeProductLine(_productLineIdPolyMaxTpu90, "PolyMax TPU90", _polymerIdTPU);
    //    MakeProductLine(_productLineIdPolyMaxTpu95, "PolyMax TPU95", _polymerIdTPU);
    //    MakeProductLine(_productLineIdPolyMaxTpu95HF, "PolyMax TPU95-HF", _polymerIdTPU);
    //    #endregion

    //    #region PC
    //    MakeProductLine(_productLineIdPolyLitePC, "PolyLite PC", _polymerIdPC);
    //    MakeProductLine(_productLineIdPolyMaxPC, "PolyMax PC", _polymerIdPC);
    //    MakeProductLine(_productLineIdPolyMaxPCFR, "PolyMaxPC-FR", _polymerIdPC);
    //    MakeProductLine(_productLineIdPolyMaxPCABS, "PolyMax PC-ABS", _polymerIdPC);
    //    MakeProductLine(_productLineIdPolyMaxPCPBT, "PolyMax PC-PBT", _polymerIdPC);
    //    #endregion

    //    #region Nylon
    //    MakeProductLine(_productLineIdPolyMideCoPA, "PolyMide CoPA", _polymerIdCoPA);
    //    MakeProductLine(_productLineIdPolyMidePA6GF, "PolyMide PA-6GF", _polymerIdPA6GF);
    //    MakeProductLine(_productLineIdPolyMidePA6CF, "PolyMide PA6-CF", _polymerIdPA6CF);
    //    MakeProductLine(_productLineIdPolyMidePA612CF, "PolyMide PA612-CF", _polymerIdPA6CF);
    //    MakeProductLine(_productLineIdPolyMidePA12CF, "PolyMide PA12-CF", _polymerIdPA12CF);
    //    #endregion

    //    #region Other
    //    MakeProductLine(_productLineIdPolySmooth, "PolySmooth", _polymerIdPVB);
    //    MakeProductLine(_productLineIdPolyCast, "PolyCast", _polymerIdPCL);
    //    MakeProductLine(_productLineIdPolySupportPla, "PolySupport for PLA", _polymerIdOther);
    //    MakeProductLine(_productLineIdPolySupportPa12, "PolySupport for PA12", _polymerIdOther);
    //    MakeProductLine(_productLineIdPolyDissolve, "PolyDissolve", _polymerIdPVA);
    //    #endregion
    //    #endregion

    //    #region Prusament
    //    MakeProductLine(_productLineIdPrusamentPla, "Prusament PLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPrusamentRPla, "Prusament rPLA", _polymerIdPLA);
    //    MakeProductLine(_productLineIdPrusamentPetg, "Prusament PETG", _polymerIdPETG);
    //    MakeProductLine(_productLineIdPrusamentPcBlend, "Prusament PC Blend", _polymerIdPC);
    //    MakeProductLine(_productLineIdPrusamentPvb, "Prusament PVB", _polymerIdPVB);
    //    MakeProductLine(_productLineIdPrusamentAsa, "Prusament ASA", _polymerIdASA);
    //    MakeProductLine(_productLineIdPrusamentPa11Cf, "Prusament PA11 Carbon Fiber", _polymerIdPA11CF);
    //    #endregion


    //    modelBuilder.Entity<ProductLine>().HasData(_productLines.Values);
    //}

    //private static ProductLine MakeProductLine(Guid id, string name, Guid polymerTypeId)
    //{ 
    //    var productLine = new ProductLine
    //    {
    //        Id = id,
    //        Name = name,
    //        PolymerTypeId = polymerTypeId,
    //        ConcurrencyStamp=id,
    //        CreatedById=_userAdminId
    //    };
    //    _productLines.Add(id, productLine);
    //    return productLine;
    //}
    #endregion
}
