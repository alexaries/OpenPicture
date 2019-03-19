using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPicture : MonoBehaviour
{
    public Transform pictureQuad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePhoto(int maxSize = -1)
    {
        //调用插件自带接口，拉取相册，内部有区分平台
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            //如果路径不为空
            if (path != null)
            {
                // 此Action为选取图片后的回调，返回一个Texture2D 
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                Debug.Log(texture.name);
                //将获得的图片显示出来
                ShowPicture(texture);
               
            }
        }, "选择图片", "image/png", maxSize);

        Debug.Log("Permission result: " + permission); 
    }

    //显示texture图片 获取quad上的material，然后将texture赋予它
    void ShowPicture(Texture2D texture)
    {
        if (pictureQuad != null && texture != null)
        {
            Material material = pictureQuad.GetComponent<Renderer>().material;
            material.mainTexture = texture;
        }
    }
}
