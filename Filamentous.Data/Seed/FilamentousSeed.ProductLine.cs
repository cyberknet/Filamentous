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
    private SequentialGuid _productLineGuid = new("D9A3F45C-81AE-4B86-B477-050000000000");
    private Dictionary<Guid, ProductLine> _productLines = new();

    #region Polymaker

    #region PLA
    private Guid _productLineIdPolyLitePla;
    private Guid _productLineIdPolyLiteSilkPla;
    private Guid _productLineIdPolyLiteDualSilkPla;
    private Guid _productLineIdPolyLiteGalaxyPla;
    private Guid _productLineIdPolyLiteStarlightPla;
    private Guid _productLineIdPolyLiteLuminousPla;
    private Guid _productLineIdPolyLiteGlowPla;
    private Guid _productLineIdPolyLiteTempPla;
    private Guid _productLineIdPolyLiteUVPla;
    
    private Guid _productLineIdPolyTerraMatte;
    private Guid _productLineIdPolyTerraDualMatte;
    private Guid _productLineIdPolyTerraGradientMatte;
    private Guid _productLineIdPolyTerraDualGradientMatte;
    private Guid _productLineIdPolyTerraMarble;
    private Guid _productLineIdPolyTerraSatin;

    private Guid _productLineIdPolySonicPla;
    private Guid _productLineIdPolySonicPlaPro;

    private Guid _productLineIdPolyLitePlaPro;
    private Guid _productLineIdPolyLiteMetallicPlaPro;
    private Guid _productLineIdPolyMaxPla;

    private Guid _productLineIdPolymakerSeasonalPacksPla;
    private Guid _productLineIdPolyLiteCosPla;
    private Guid _productLineIdLightWeightPla;
    private Guid _productLineIdPolymakerCarbonFiberPla;
    private Guid _productLineIdPolyWoodPla;
    private Guid _productLineIdPolymakerDraftPla;
    private Guid _productLineIdPolymakerMattePla;
    #endregion

    #region ABS
    private Guid _productLineIdPolyLiteAbs;
    private Guid _productLineIdPolyLiteMetallicAbs;
    private Guid _productLineIdPolyLiteGalaxyAbs;
    private Guid _productLineIdPolyLiteNeonAbs;
    #endregion

    #region ASA
    private Guid _productLineIdPolyLiteAsa;
    private Guid _productLineIdPolyLiteGalaxyAsa;
    #endregion

    #region PETG
    private Guid _productLineIdPolyLitePetg;
    private Guid _productLineIdPolyLiteTranslucentPetg;
    private Guid _productLineIdPolyMaxPetg;
    private Guid _productLineIdPolyMaxPetgEsd;
    #endregion

    #region TPU
    private Guid _productLineIdPolyMaxTpu90;
    private Guid _productLineIdPolyMaxTpu95;
    private Guid _productLineIdPolyMaxTpu95HF;
    #endregion

    #region PC
    private Guid _productLineIdPolyLitePC;
    private Guid _productLineIdPolyMaxPC;
    private Guid _productLineIdPolyMaxPCFR;
    private Guid _productLineIdPolyMaxPCABS;
    private Guid _productLineIdPolyMaxPCPBT;
    #endregion

    #region Nylon
    private Guid _productLineIdPolyMideCoPA;
    private Guid _productLineIdPolyMidePA6GF;
    private Guid _productLineIdPolyMidePA6CF;
    private Guid _productLineIdPolyMidePA612CF;
    private Guid _productLineIdPolyMidePA12CF;
    #endregion

    #region Other
    private Guid _productLineIdPolySmooth;
    private Guid _productLineIdPolyCast;
    private Guid _productLineIdPolySupportPla;
    private Guid _productLineIdPolySupportPa12;
    private Guid _productLineIdPolyDissolve;
    #endregion

    #endregion

    #region Prusament
    private Guid _productLineIdPrusamentPla;
    private Guid _productLineIdPrusamentRPla;
    private Guid _productLineIdPrusamentPetg;
    private Guid _productLineIdPrusamentPcBlend;
    private Guid _productLineIdPrusamentPvb;
    private Guid _productLineIdPrusamentAsa;
    private Guid _productLineIdPrusamentPa11Cf;
    private Guid _productLineIdPrusamentPetgCf;
    private Guid _productLineIdPrusamentPcBlendCf;
    #endregion

    private void InitializeProductLines()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _productLineIdPolyLitePla = _productLineGuid.Next(); 
        _productLineIdPolyLiteSilkPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteDualSilkPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteGalaxyPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteStarlightPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteLuminousPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteGlowPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteTempPla = _productLineGuid.Next(); 
        _productLineIdPolyLiteUVPla = _productLineGuid.Next(); 
        _productLineIdPolyTerraMatte = _productLineGuid.Next(); 
        _productLineIdPolyTerraDualMatte = _productLineGuid.Next(); 
        _productLineIdPolyTerraGradientMatte = _productLineGuid.Next(); 
        _productLineIdPolyTerraDualGradientMatte = _productLineGuid.Next(); 
        _productLineIdPolyTerraMarble = _productLineGuid.Next(); 
        _productLineIdPolyTerraSatin = _productLineGuid.Next(); 
        _productLineIdPolySonicPla = _productLineGuid.Next();
        _productLineIdPolySonicPlaPro = _productLineGuid.Next();
        _productLineIdPolyLitePlaPro = _productLineGuid.Next();
        _productLineIdPolyLiteMetallicPlaPro = _productLineGuid.Next();
        _productLineIdPolyMaxPla = _productLineGuid.Next();
        _productLineIdPolymakerSeasonalPacksPla = _productLineGuid.Next();
        _productLineIdPolyLiteCosPla = _productLineGuid.Next();
        _productLineIdLightWeightPla = _productLineGuid.Next();
        _productLineIdPolymakerCarbonFiberPla = _productLineGuid.Next();
        _productLineIdPolyWoodPla = _productLineGuid.Next();
        _productLineIdPolymakerDraftPla = _productLineGuid.Next();
        _productLineIdPolymakerMattePla = _productLineGuid.Next();
        _productLineIdPolyLiteAbs = _productLineGuid.Next();
        _productLineIdPolyLiteMetallicAbs = _productLineGuid.Next();
        _productLineIdPolyLiteGalaxyAbs = _productLineGuid.Next();
        _productLineIdPolyLiteNeonAbs = _productLineGuid.Next();
        _productLineIdPolyLiteAsa = _productLineGuid.Next();
        _productLineIdPolyLiteGalaxyAsa = _productLineGuid.Next();
        _productLineIdPolyLitePetg = _productLineGuid.Next();
        _productLineIdPolyLiteTranslucentPetg = _productLineGuid.Next();
        _productLineIdPolyMaxPetg = _productLineGuid.Next();
        _productLineIdPolyMaxPetgEsd = _productLineGuid.Next();
        _productLineIdPolyMaxTpu90 = _productLineGuid.Next();
        _productLineIdPolyMaxTpu95 = _productLineGuid.Next();
        _productLineIdPolyMaxTpu95HF = _productLineGuid.Next();
        _productLineIdPolyLitePC = _productLineGuid.Next();
        _productLineIdPolyMaxPC = _productLineGuid.Next();
        _productLineIdPolyMaxPCFR = _productLineGuid.Next();
        _productLineIdPolyMaxPCABS = _productLineGuid.Next();
        _productLineIdPolyMaxPCPBT = _productLineGuid.Next();
        _productLineIdPolyMideCoPA = _productLineGuid.Next();
        _productLineIdPolyMidePA6GF = _productLineGuid.Next();
        _productLineIdPolyMidePA6CF = _productLineGuid.Next();
        _productLineIdPolyMidePA612CF = _productLineGuid.Next();
        _productLineIdPolyMidePA12CF = _productLineGuid.Next();
        _productLineIdPolySmooth = _productLineGuid.Next();
        _productLineIdPolyCast = _productLineGuid.Next();
        _productLineIdPolySupportPla = _productLineGuid.Next();
        _productLineIdPolySupportPa12 = _productLineGuid.Next();
        _productLineIdPolyDissolve = _productLineGuid.Next();
        _productLineIdPrusamentPla = _productLineGuid.Next();
        _productLineIdPrusamentRPla = _productLineGuid.Next();
        _productLineIdPrusamentPetg = _productLineGuid.Next();
        _productLineIdPrusamentPcBlend = _productLineGuid.Next();
        _productLineIdPrusamentPvb = _productLineGuid.Next();
        _productLineIdPrusamentAsa = _productLineGuid.Next();
        _productLineIdPrusamentPa11Cf = _productLineGuid.Next();
        _productLineIdPrusamentPetgCf = _productLineGuid.Next();
        _productLineIdPrusamentPcBlendCf = _productLineGuid.Next();
    }

private void ProductLines(ModelBuilder modelBuilder)
    {
        #region Polymaker
        #region PLA
        #region PolyLite
        MakeProductLine(_productLineIdPolyLitePla, _brandIdPolymaker, "PolyLite PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteSilkPla, _brandIdPolymaker, "PolyLite Silk PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteDualSilkPla, _brandIdPolymaker, "PolyLite Dual Silk PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteGalaxyPla, _brandIdPolymaker, "PolyLite Galaxy PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteStarlightPla, _brandIdPolymaker, "PolyLite Starlight PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteLuminousPla, _brandIdPolymaker, "PolyLite Luminous PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteGlowPla, _brandIdPolymaker, "PolyLite Glow PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyLiteTempPla, _brandIdPolymaker, "PolyLite Temperature Color Changing PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyLiteUVPla, _brandIdPolymaker, "PolyLite UV Color Changing PLA", _polymerIdPLA, true, 215, 60);
        #endregion

        #region PolyTerra
        MakeProductLine(_productLineIdPolyTerraMatte, _brandIdPolymaker, "PolyTerra Matte PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyTerraDualMatte, _brandIdPolymaker, "PolyTerra Dual Matte PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyTerraGradientMatte, _brandIdPolymaker, "PolyTerra Gradient Matte PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyTerraDualGradientMatte, _brandIdPolymaker, "PolyTerra Dual Gradient Matte PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyTerraMarble, _brandIdPolymaker, "PolyTerra Marble PLA", _polymerIdPLA, true, 215, 60);
        MakeProductLine(_productLineIdPolyTerraSatin, _brandIdPolymaker, "PolyTerra Satin PLA", _polymerIdPLA, true, 215, 60);
        #endregion

        #region High Speed
        MakeProductLine(_productLineIdPolySonicPla, _brandIdPolymaker, "PolySonic PLA", _polymerIdPLA, false, 220, 60);
        MakeProductLine(_productLineIdPolySonicPlaPro, _brandIdPolymaker, "PolySonic PLA Pro", _polymerIdPLA, false, 220, 60);
        #endregion

        #region PolyLite Pro/Max
        MakeProductLine(_productLineIdPolyLitePlaPro, _brandIdPolymaker, "PolyLite PLA Pro", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteMetallicPlaPro, _brandIdPolymaker, "PolyLite Metallic PLA Pro", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyMaxPla, _brandIdPolymaker, "PolyMax PLA", _polymerIdPLA, false, 215, 60);
        #endregion

        #region Other
        MakeProductLine(_productLineIdPolymakerSeasonalPacksPla, _brandIdPolymaker, "Seasonal Packs PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolyLiteCosPla, _brandIdPolymaker, "PolyLite CosPLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdLightWeightPla, _brandIdPolymaker, "Light Weight PLA", _polymerIdPLA, false, 200, 50);
        MakeProductLine(_productLineIdPolymakerCarbonFiberPla, _brandIdPolymaker, "Carbon Fiber PLA", _polymerIdPLA, true, 220, 70);
        MakeProductLine(_productLineIdPolyWoodPla, _brandIdPolymaker, "PolyWood PLA", _polymerIdPLA, true, 200, 50);
        MakeProductLine(_productLineIdPolymakerDraftPla, _brandIdPolymaker, "Draft PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPolymakerMattePla, _brandIdPolymaker, "Matte PLA for Production", _polymerIdPLA, false, 215, 60);
        #endregion
        #endregion

        #region ABS
        MakeProductLine(_productLineIdPolyLiteAbs, _brandIdPolymaker, "PolyLite ABS", _polymerIdABS, false, 255, 110);
        MakeProductLine(_productLineIdPolyLiteMetallicAbs, _brandIdPolymaker, "PolyLite Metallic ABS", _polymerIdABS, false, 255, 110);
        MakeProductLine(_productLineIdPolyLiteGalaxyAbs, _brandIdPolymaker, "PolyLite Galaxy ABS", _polymerIdABS, false, 255, 110);
        MakeProductLine(_productLineIdPolyLiteNeonAbs, _brandIdPolymaker, "PolyLite Neon ABS", _polymerIdABS, false, 255, 110);
        #endregion

        #region ASA
        MakeProductLine(_productLineIdPolyLiteAsa, _brandIdPolymaker, "PolyLite ASA", _polymerIdASA, false, 260, 110);
        MakeProductLine(_productLineIdPolyLiteGalaxyAsa, _brandIdPolymaker, "PolyLite Galaxy ASA", _polymerIdASA, false, 260, 110);
        #endregion

        #region PETG
        MakeProductLine(_productLineIdPolyLitePetg, _brandIdPolymaker, "PolyLite PETG", _polymerIdPETG, false, 240, 90);
        MakeProductLine(_productLineIdPolyLiteTranslucentPetg, _brandIdPolymaker, "PolyLite Translucent PETG", _polymerIdPETG, false, 240, 90);
        MakeProductLine(_productLineIdPolyMaxPetg, _brandIdPolymaker, "PolyMax PETG", _polymerIdPETG, false, 240, 90);
        MakeProductLine(_productLineIdPolyMaxPetgEsd, _brandIdPolymaker, "PolyMax PETG-ESD", _polymerIdPETG, false, 240, 90);
        #endregion

        #region TPU
        MakeProductLine(_productLineIdPolyMaxTpu90, _brandIdPolymaker, "PolyMax TPU90", _polymerIdTPU, false, 220, 50);
        MakeProductLine(_productLineIdPolyMaxTpu95, _brandIdPolymaker, "PolyMax TPU95", _polymerIdTPU, false, 220, 50);
        MakeProductLine(_productLineIdPolyMaxTpu95HF, _brandIdPolymaker, "PolyMax TPU95-HF", _polymerIdTPU, false, 210, 50);
        #endregion

        #region PC
        MakeProductLine(_productLineIdPolyLitePC, _brandIdPolymaker, "PolyLite PC", _polymerIdPC, false, 260, 105);
        MakeProductLine(_productLineIdPolyMaxPC, _brandIdPolymaker, "PolyMax PC", _polymerIdPC, false, 260, 105);
        MakeProductLine(_productLineIdPolyMaxPCFR, _brandIdPolymaker, "PolyMaxPC-FR", _polymerIdPC, false, 260, 105);
        MakeProductLine(_productLineIdPolyMaxPCABS, _brandIdPolymaker, "PolyMax PC-ABS", _polymerIdPC, false, 260, 105);
        MakeProductLine(_productLineIdPolyMaxPCPBT, _brandIdPolymaker, "PolyMax PC-PBT", _polymerIdPC, false, 270, 115);
        #endregion

        #region Nylon
        MakeProductLine(_productLineIdPolyMideCoPA, _brandIdPolymaker, "PolyMide CoPA", _polymerIdCoPA, false, 260, 50);
        MakeProductLine(_productLineIdPolyMidePA6GF, _brandIdPolymaker, "PolyMide PA-6GF", _polymerIdPA6GF, true, 290, 50);
        MakeProductLine(_productLineIdPolyMidePA6CF, _brandIdPolymaker, "PolyMide PA6-CF", _polymerIdPA6CF, true, 290, 50);
        MakeProductLine(_productLineIdPolyMidePA612CF, _brandIdPolymaker, "PolyMide PA612-CF", _polymerIdPA6CF, true, 275, 50);
        MakeProductLine(_productLineIdPolyMidePA12CF, _brandIdPolymaker, "PolyMide PA12-CF", _polymerIdPA12CF, true, 275, 50);
        #endregion

        #region Other
        MakeProductLine(_productLineIdPolySmooth, _brandIdPolymaker, "PolySmooth", _polymerIdPVB, false, 205, 50);
        MakeProductLine(_productLineIdPolyCast, _brandIdPolymaker, "PolyCast", _polymerIdPCL, false, 205, 60);
        MakeProductLine(_productLineIdPolySupportPla, _brandIdPolymaker, "PolySupport for PLA", _polymerIdOther, false, 225, 60);
        MakeProductLine(_productLineIdPolySupportPa12, _brandIdPolymaker, "PolySupport for PA12", _polymerIdOther, false, 285, 80);
        MakeProductLine(_productLineIdPolyDissolve, _brandIdPolymaker, "PolyDissolve", _polymerIdPVA, false, 220, 60);
        #endregion
        #endregion

        #region Prusament
        MakeProductLine(_productLineIdPrusamentPla, _brandIdPrusament, "Prusament PLA", _polymerIdPLA, false, 215, 60);
        MakeProductLine(_productLineIdPrusamentRPla, _brandIdPrusament, "Prusament rPLA", _polymerIdPLA, false, 205, 50);
        MakeProductLine(_productLineIdPrusamentPetg, _brandIdPrusament, "Prusament PETG", _polymerIdPETG, false, 250, 80);
        MakeProductLine(_productLineIdPrusamentPetgCf, _brandIdPrusament, "Prusament PETG-CF", _polymerIdPETG, true, 265, 90);
        MakeProductLine(_productLineIdPrusamentPcBlend, _brandIdPrusament, "Prusament PC Blend", _polymerIdPC, false, 275, 110);
        MakeProductLine(_productLineIdPrusamentPcBlendCf, _brandIdPrusament, "Prusament PC Blend", _polymerIdPC, true, 285, 110);
        MakeProductLine(_productLineIdPrusamentPvb, _brandIdPrusament, "Prusament PVB", _polymerIdPVB, false, 215, 75);
        MakeProductLine(_productLineIdPrusamentAsa, _brandIdPrusament, "Prusament ASA", _polymerIdASA, false, 260, 110);
        MakeProductLine(_productLineIdPrusamentPa11Cf, _brandIdPrusament, "Prusament PA11 Carbon Fiber", _polymerIdPA11CF, true, 285, 110);
        #endregion

        Console.WriteLine($" * Entity ProductLine has {_productLines.Keys.Count} rows in seed data.");
        modelBuilder.Entity<ProductLine>().HasData(_productLines.Values.ToArray());
    }

    private void MakeProductLine(Guid id, Guid brandId, string name, Guid polymerTypeId, bool isAbrasive, int hotEndTemperature, int bedTemperature)
    {
        var productLine = new ProductLine
        {
            Id = id,
            BrandId = brandId,
            Name = name,
            PolymerId = polymerTypeId,
            IsAbrasive = isAbrasive,
            HotEndTemperature = hotEndTemperature,
            BedTemperature = bedTemperature,
            ConcurrencyStamp = id,
            CreatedById = _userAdminId.ToString()
        };
        try
        {
            if (!_productLines.ContainsKey(productLine.Id))
                _productLines.Add(id, productLine);
            //else
            //    Console.WriteLine($"Using existing ProductLine {name} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Unable to create ProductLine {name} with id {id}: ${ex.Message}");
        }
    }
}
