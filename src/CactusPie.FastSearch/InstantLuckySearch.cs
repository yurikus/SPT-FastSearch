using System.Reflection;
using SPT.Reflection.Patching;

namespace CactusPie.FastSearch;

/*
GClass3302 - search operation
  method_6: performs search, looks at buffs
    if bool_0 = true, Task.Delay(0) 

  bool_0: IsLuckySearch
  bool_1: IsAlreadySearched

  method_5:
    if (!bool_1) {
      if (!bool_0) {
        delay(2000);
      }
      SearchItem();  
    }
     
        
GClass3303 - looting luck
  bool_0: looting luck
    method_4: plays looting_luck2 sound

*/

public class InstantLuckySearch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return typeof(GClass3302).GetMethod(nameof(GClass3302.method_5), BindingFlags.Instance | BindingFlags.Public);
    }

    [PatchPrefix]
    public static void PatchPrefix(GClass3302 __instance)
    {
        if (!FastSearchPlugin.InstantlyRevealEverything.Value)
            return;

        __instance.bool_0 = true;
    }
}
