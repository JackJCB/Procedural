using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise_Filter_Factory 
{
    public static iNoise_Filter CreateNoiseFilter(Noise_Settings settings)
    {
        switch(settings.filterType)
        {
            case Noise_Settings.FilterType.Simple:
                return new Noise_Filter(settings.simpleNoiseSettings);
            case Noise_Settings.FilterType.Rigid:
                return new Rigid_Noise_Filter(settings.rigidNoiseSettings);

        }
        return null;
    }
}
