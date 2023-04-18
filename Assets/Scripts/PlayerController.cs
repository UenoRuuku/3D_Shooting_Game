using UnityEngine;

/**
 * 功能：角色移动控制[键盘控制移动，鼠标控制朝向]
 *
 */
public class PlayerController : MonoBehaviour
{
    //速度变量
    public float speed;
    //定义角色控制器
    public CharacterController cc;
    //摄像机
    public Camera viewCamera;
    void Start()
    {
        //组件cc变量
        cc = transform.GetComponent<CharacterController>();

        //速度赋值
        speed = 5;

        //当前主摄像机
        viewCamera = Camera.main;
    }

    void Update()
    {
        //调用移动方法
        move_by_cc();
    }
    void move_by_cc()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //垂直方面的输入获取
        float z = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            //移动方向
            Vector3 toward_dir = new Vector3(x,0,z);
            //不同于move函数，这里以秒为单位不能*Time.deltatime，不然会无法移动
            //（normalized指单位化，即此时该向量不具备大小仅具备方向）
            cc.SimpleMove(toward_dir.normalized * speed);
        }

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        Vector3 point = Vector3.zero;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            point = ray.GetPoint(rayDistance);

        }
        Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(heightCorrectedPoint);
    }
}

