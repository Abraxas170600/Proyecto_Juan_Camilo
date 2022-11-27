using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private GameObject _graphicObject;
    private Renderer _renderer;
    public void UpdateMaterial(Material material)
    {
        _renderer = _graphicObject.GetComponent<Renderer>();
        _renderer.material = material;
    }

    private void OnDestroy()
    {
        Destroy(_renderer.material);
    }
}
