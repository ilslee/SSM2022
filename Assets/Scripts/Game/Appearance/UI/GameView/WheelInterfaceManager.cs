using System.Collections;
using System.Collections.Generic;
using ssm.game.structure;
using UnityEngine;
using UnityEngine.EventSystems;
using ssm.ui;
namespace ssm.game.appearance{
    public class WheelInterfaceManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
    {
        // public CanvasScaler canvasScaler;
        public UIAnimationManager anim;
        public GameEvent gameEvent;
        private Vector2[] iconPositions;
        private Vector2 wheelCenter;
        public RectTransform[] icons;
        private float clickAreaRadius;
        private int currentWheelID;
        private bool isSwordRight;
        public void Start(){
            isSwordRight = true;
            currentWheelID = -1;
            InitIconPose();
            SetIcon();

            //SetWheelCenter
            RectTransform wheelRect = gameObject.GetComponent<RectTransform>();
            // float screenScaleX = Screen.width / canvasScaler.referenceResolution.x; // 화면 해상도가 바뀌는 것을 보정해
            // float screenScaleY = Screen.height / canvasScaler.referenceResolution.y; // 화면 해상도가 바뀌는 것을 보정해
            // wheelCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f) + wheelRect.anchoredPosition * new Vector2(screenScaleX, screenScaleY);
            wheelCenter = new Vector2(Screen.width * 0.5f, wheelRect.anchoredPosition.y); // 가로 정렬 : 중앙 / 세로 정렬 : 하단
            // anim.AddAnimation(new UIAnimationToken(gameObject.GetComponent<RectTransform>(), UIAnimationToken.AnimationType.Posiion, Vector3.zero, 1f, anim.acc.GetCurve(AnimationCurveContainer.Type.FastRebound1) ));

            //Set Click Area 
            float canvasSizeModifier = gameObject.transform.lossyScale.x;
            clickAreaRadius = gameObject.GetComponent<RectTransform>().sizeDelta.x * canvasSizeModifier * 0.5f;

            AnimateWheelDisabled(true);
        }

        private void InitIconPose(){
            iconPositions = new Vector2[6];
            float degreeOffset = 60f;
            float buttonDistance = 172f;
            float[] radians = { Mathf.Deg2Rad * (degreeOffset-0f), Mathf.Deg2Rad * (degreeOffset-60f), 
                                Mathf.Deg2Rad * (degreeOffset-120), Mathf.Deg2Rad * (degreeOffset-180), 
                                Mathf.Deg2Rad * (degreeOffset-240), Mathf.Deg2Rad * (degreeOffset-300)};
            iconPositions[0] = new Vector2(Mathf.Cos(radians[0]), Mathf.Sin(radians[0])) * buttonDistance; //1시
            iconPositions[1] = new Vector2(Mathf.Cos(radians[1]), Mathf.Sin(radians[1])) * buttonDistance; // 3시
            iconPositions[2] = new Vector2(Mathf.Cos(radians[2]), Mathf.Sin(radians[2])) * buttonDistance; // 5시
            iconPositions[3] = new Vector2(Mathf.Cos(radians[3]), Mathf.Sin(radians[3])) * buttonDistance; // 7시
            iconPositions[4] = new Vector2(Mathf.Cos(radians[4]), Mathf.Sin(radians[4])) * buttonDistance; // 9시
            iconPositions[5] = new Vector2(Mathf.Cos(radians[5]), Mathf.Sin(radians[5])) * buttonDistance; // 11시
        }
        public void SetIcon(){
            if(isSwordRight == true){
                icons[0].anchoredPosition = iconPositions[1]; //Attack
                icons[1].anchoredPosition = iconPositions[0]; //Strike
                icons[2].anchoredPosition = iconPositions[4]; //Defence
                icons[3].anchoredPosition = iconPositions[5]; //Charge
            }else{
                icons[0].anchoredPosition = iconPositions[4]; //Attack
                icons[1].anchoredPosition = iconPositions[5]; //Strike
                icons[2].anchoredPosition = iconPositions[1]; //Defence
                icons[3].anchoredPosition = iconPositions[0]; //Charge
            }
            icons[4].anchoredPosition = iconPositions[3]; //Rest
            icons[5].anchoredPosition = iconPositions[2]; //Avoid
            
        }
        private RectTransform GetIconViaWheelID(int wheelID){
            if(isSwordRight == true){
                switch(wheelID){
                    case 0:
                    return icons[1];
                    case 1:
                    return icons[0];
                    case 2:
                    return icons[5];
                    case 3:
                    return icons[4];
                    case 4:
                    return icons[2];
                    case 5:
                    return icons[3];
                }
            }else{
                switch(wheelID){
                    case 0:
                    return icons[3];
                    case 1:
                    return icons[2];
                    case 2:
                    return icons[5];
                    case 3:
                    return icons[4];
                    case 4:
                    return icons[0];
                    case 5:
                    return icons[1];
                }
            }
            return null;
        }
        public void OnPointerDown(PointerEventData p)
        {
            Debug.Log("WheelInterfaceManager : Pressed");
            Debug.Log(" scale " +gameObject.transform.lossyScale);
            currentWheelID = GetWheelIndex(p.position);
            AnimateIconActivated(currentWheelID);
        }
        public void OnPointerUp(PointerEventData p)
        {
            Debug.Log("WheelInterfaceManager : Released");
            currentWheelID = GetWheelIndex(p.position);
            AnimateIconDeactivated(currentWheelID);
            if(currentWheelID >=0){
                gameEvent.Raise(GameEvent.MOTION_SELECTED, currentWheelID);
            }
        }
        public void OnDrag(PointerEventData p)
        {
            
            if(currentWheelID != GetWheelIndex(p.position)){
                AnimateIconDeactivated(currentWheelID);
                currentWheelID = GetWheelIndex(p.position);
                AnimateIconActivated(currentWheelID);
            }
        }
        private int GetWheelIndex(Vector2 mousePos){
            Vector2 wheelCenter = (Vector2)gameObject.GetComponent<RectTransform>().position;
            float distanceFronCenter = Vector2.Distance(mousePos, wheelCenter);
            float angle = Vector2.SignedAngle(Vector2.up, mousePos - wheelCenter ) * -1f; // 12시부터 시계방향으로 앵글 추출
            if(angle < 0f) angle += 360f;
            int wheelID = (int)Mathf.Floor(angle / 60f);
            // float angle = Vector2.SignedAngle(wheelCenter, mousePos - wheelCenter);
            // Debug.Log("MousePose : "+ mousePos + " / Zero : " + Vector2.zero);
            // Debug.Log("Distance : "+ distanceFronCenter + " / Angle : " + angle);
            if(distanceFronCenter > clickAreaRadius) return -1;
            else return wheelID;
            // return 0;
        }

        private void AnimateIconActivated(int activatedWheelID = -1){
            if(activatedWheelID < 0 )return;
            Vector3 scaleActivated = Vector3.one * 1.5f;
            anim.AddAnimation(new UIAnimationScale(GetIconViaWheelID(activatedWheelID), 1.5f, 0.3f, anim.acc.fastRebound1 ));
        }
        private void AnimateIconDeactivated(int deactivatedWheelID = -1){
            if(deactivatedWheelID < 0 )return;
            Vector3 scaleDeactivated = Vector3.one;
            anim.AddAnimation(new UIAnimationScale(GetIconViaWheelID(deactivatedWheelID), 1f, 0.3f, anim.acc.fastRebound1 ));
        }
        private void AnimateWheelEnabled(){
            Vector3 scaleIconEnabled = Vector3.one;
            for (int i = 0; i < icons.Length; i++)
            {
                anim.AddAnimation(new UIAnimationScale(icons[i], 1f, 0.3f, anim.acc.fastRebound1 ));    
            }
        }
        //isInstant는 처음 시작시에만 반영
        private void AnimateWheelDisabled(bool isInstant = false){
            Vector3 scaleIconEnabled = Vector3.one * 0.5f;
            float duration = 0.3f;
            if(isInstant == true) duration = 0f;
            for (int i = 0; i < icons.Length; i++)
            {
                anim.AddAnimation(new UIAnimationScale(icons[i], 0.5f, duration, anim.acc.fastRebound1 ));    
            }
        }
        
        public void ManageGameEvent(string type, float value){
            switch(type){
                case GameEvent.TEST_WHEEL_ENABLE:
                AnimateWheelEnabled();
                break;
                case GameEvent.TEST_WHEEL_DISABLE:
                AnimateWheelDisabled();
                break;
            }
        }
    }
}