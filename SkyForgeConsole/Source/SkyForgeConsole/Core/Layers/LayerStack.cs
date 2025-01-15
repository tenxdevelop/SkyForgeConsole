/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SkyForgeConsole
{
    public sealed class LayerStack : IEnumerable<Layer>
    {
        private List<Layer> m_layers;
        private List<Layer> m_overlayLayers;
        public int GetLength() => m_layers.Count + m_overlayLayers.Count;

        public LayerStack()
        {
           m_layers = new List<Layer>();
           m_overlayLayers = new List<Layer>();
        }
        
        public void PushLayer(Layer layer)
        {
            CheckLayerIsNull(layer, "We push layer is null in layerStack");
            m_layers.Add(layer);
        }
        
        public void PopLayer(Layer layer)
        {
            CheckLayerIsNull(layer, "We pop layer is null in layerStack");
            var layerToRemove = m_layers.Find(currentLayer => currentLayer.Equals(layer));
            m_layers.Remove(layerToRemove);
        }

        public void PushOverlay(Layer layer)
        {
            CheckLayerIsNull(layer, "We push overlay is null in layerStack");
            m_overlayLayers.Add(layer);
        }

        public void PopOverlay(Layer layer)
        {
            CheckLayerIsNull(layer, "We pop overlay is null in layerStack");
            var layerToRemove = m_overlayLayers.Find(currentLayer => currentLayer.Equals(layer));
            m_overlayLayers.Remove(layerToRemove);
        }

        public Layer GetLayer(int index)
        {
            return m_layers[index];
        }

        public Layer[] GetLayers()
        {
            var result = m_layers.Concat(m_overlayLayers).Reverse().ToArray();
            return result;
        }

        public IEnumerator<Layer> GetEnumerator()
        {
            for (var index = m_overlayLayers.Count - 1; index >= 0; index--)
            {
                yield return m_overlayLayers[index];
            }

            for (var index = m_layers.Count - 1; index >= 0; index--)
            {
                yield return m_layers[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckLayerIsNull(Layer layer, string message)
        {
            if (layer is null)
            {
                Log.CoreLogger?.Logging(message, LogLevel.Error);
                throw new ArgumentException(message);
            }
        }
    }
}

