using UnityEngine;
using UnityEngine.InputSystem;

public class Pleyer : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.wKey.IsPressed())
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }

        RaycastHit raycast;
        CreateAndShow0fRay(Vector3.zero, transform.position, out raycast, Color.red);

        CreateAndShow0fRay(transform.position, new Vector3(0, 0, moveSpeed * Time.deltaTime), out raycast, Color.yellow);

        Vector3 downVector = transform.position + new Vector3(0, -2, 0);
        CreateAndShow0fRay(transform.position, downVector, out raycast, Color.blue);
        CreateAndShow0fRay(raycast.point, raycast.normal, out raycast, Color.green);
    }

   /// <summary>
   /// ベクトルを可視化して、光線を飛ばすメゾット
   /// </summary>
   /// <param name="start"></param>
   /// <param name="target"></param>
   /// <param name="color"></param>
    
    public void CreateAndShow0fRay( Vector3 start, Vector3 target, out RaycastHit hit, Color color )
    {
        // Vector3.Cross(); //外積
        // Vector3.Dot();　//内積


        // ベクトルの差分
        Vector3 difference = target - start;

        //ベクトルの距離
        float distance = Vector3.Distance(start, target);

        //ベクトルの可視化
        Debug.DrawRay(start, difference, color, 0, false);

        //光線を飛ばす
        // Raycast(開始点、向き、out 衝突情報, 距離、マスク );
        Physics.Raycast(start, difference, out hit, distance, LayerMask.GetMask("Terrain"));
    }
}
