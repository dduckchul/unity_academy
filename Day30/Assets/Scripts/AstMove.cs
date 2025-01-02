using UnityEngine;

public class AstMove : MonoBehaviour
{
    public Vector3 moveAmount; // 이동할 거리를 기억시킬 변수
    private Vector3 tempPosition;
    private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        // moveAmount = new Vector3(0, -0.02f, 0);
        tempPosition = transform.position; // Start와 동시에 원점을 임시 좌표에 대입
        moveSpeed = Random.Range(0.01f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        # region 좌표 움직이기
        // // 만약 y 수치가 -5보다 더 아래로 내려간다면?
        // if (transform.position.y < -5)
        // {
        //     transform.Translate(0, 10, 0);
        // }
        //
        // // 기존위치 + 저장위치, 원본에 반영
        // // transform.position += moveAmount;
        // transform.Translate(moveAmount); // 위와 똑같은 행동 하는 코드, 소괄호 안에 있는 인자만큼 움직임
        # endregion 좌표 움직이기 end
        
        // 임시 포지션 업데이트
        // 1. 임시 포지션 y수치는 매 프레임 -특정 값 만큼 이동한다.
        tempPosition.y -= moveSpeed;
        
        // 2. 만약 y 수치가 -5보다 작아지면 y에 15를 더해서 위로 올려준다.
        // 3. x에는 -8에서 8 사이 랜덤한 값을 가진다.
        if (tempPosition.y < -5)
        {
            tempPosition.y += 15;
            tempPosition.x = Random.Range(-8, 8);
            moveSpeed = Random.Range(0.01f, 0.05f);
        }
        
        // 유니티의 랜덤 -> Random.Range(n,m) 정수일경우 n ~ m-1 사이의 숫자 반환 (이상 ~ 미만)
        //            -> n과 m이 실수일 경우 -> 2.5, 7.5의 경우? 그 사이 실수가 나온다. 2.5나 7,5도 나옴 (이상 ~ 이하)
        
        // =================
        // 임시 포지션 반영
        transform.position = tempPosition;
    }
}