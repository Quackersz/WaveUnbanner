using HarmonyLib;
using Steamworks;

[HarmonyPatch(typeof(SteamUser), "GetSteamID")]
public class PatchSteamID
{
    public static bool Prefix(ref CSteamID __result)
    {
        __result = new CSteamID(12345678901234567); 
        return false; 
    }
}