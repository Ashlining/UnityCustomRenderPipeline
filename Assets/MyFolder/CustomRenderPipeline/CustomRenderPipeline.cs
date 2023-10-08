using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline
{
    private CameraRender render = new CameraRender();

    private bool useDynamicBatching, useGPUInstancing;

    private ShadowSettings shadowSettings;
    public CustomRenderPipeline(bool useDynamicBatching,bool useGPUInstancing,bool useSRPBatcher,ShadowSettings shadowSettings)
    {
        this.shadowSettings = shadowSettings;
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
        GraphicsSettings.lightsUseLinearIntensity = true;
    }
    
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        foreach (var camera in cameras)
        {
            render.Render(context, camera, useDynamicBatching, useGPUInstancing ,shadowSettings);
        }
    }
}
