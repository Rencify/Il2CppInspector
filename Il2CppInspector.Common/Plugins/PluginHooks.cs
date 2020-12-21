﻿/*
    Copyright 2020 Katy Coe - http://www.djkaty.com - https://github.com/djkaty

    All rights reserved.
*/

// This is the ONLY line to update when the API version changes
using System.IO;
using Il2CppInspector.PluginAPI.V100;
using Il2CppInspector.Reflection;

namespace Il2CppInspector
{
    // Hooks we provide to plugins which can choose whether or not to provide implementations
    internal static class PluginHooks
    {
        public static PluginPostProcessMetadataEventInfo PostProcessMetadata(Metadata metadata)
            => PluginManager.Try<IPostProcessMetadata, PluginPostProcessMetadataEventInfo>((p, e) => p.PostProcessMetadata(metadata, e));

        public static PluginPreProcessMetadataEventInfo PreProcessMetadata(MemoryStream stream)
            => PluginManager.Try<IPreProcessMetadata, PluginPreProcessMetadataEventInfo>((p, e) => {
                    stream.Position = 0;
                    p.PreProcessMetadata(stream, e);
                });

        public static PluginPostProcessTypeModelEventInfo PostProcessTypeModel(TypeModel typeModel)
            => PluginManager.Try<IPostProcessTypeModel, PluginPostProcessTypeModelEventInfo>((p, e) => p.PostProcessTypeModel(typeModel, e));
    }
}