using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform[] bgSlots;
    public float scrollingSpeed = 2.5f;

    const float Background_Width = 13.6f;

    private void Awake()
    {
        bgSlots = new Transform[transform.childCount];
        for( int i=0; i<transform.childCount; i++)  // 정확한 인덱스가 필요할 때 유리
        {
            bgSlots[i] = transform.GetChild(i);
        }        
    }

    private void Update()
    {
        float minusX = transform.position.x - Background_Width;
        foreach (Transform slot in bgSlots)  // 속도가 그냥 for보다 빠름
        {
            slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);

            if( slot.position.x < minusX )  
            {
                //Debug.Log($"{slot.name}은 충분히 왼쪽으로 이동했다.");
                // 오른쪽으로 Background_Width의 3배(bgSlots.Length에 3개가 들어있으니까) 만큼 이동
                slot.Translate(Background_Width * bgSlots.Length * transform.right);    
            }
        }
    }
}
