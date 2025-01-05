using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MainCamera : MonoBehaviour
{
    bool cameraShake = false;

    Transform ShakeTr;

    public class cShakeInfo
    {
        public float StartDelay;
        public bool UseTotalTime;
        public float TotalTime;
        public Vector3 Dest;
        public Vector3 Shake;
        public Vector3 Dir;

        public float RemainDist;
        public float RemainCountDis;

        public bool useCount;
        public int Count;

        public float Velocity;

        public bool UseDamping;
        public float Damping;
        public float DampingTime;
    }

    cShakeInfo ShakeInfo = new cShakeInfo();

    Vector3 OrcPos;

    float FovX = 0.2f;
    float FovY = 0.2f;

    float Left = 1.0f;
    float Right = -1.0f;


    private void Awake()
    {
        Shared.MainCamera = this;
        OrcPos = transform.position;

        InitShake();
    }

    private void InitShake()
    {
        ShakeTr = transform.parent;

        cameraShake = false;
    }

    void ResetShakeTr()
    {
        ShakeTr.localPosition = Vector3.zero;
        cameraShake = false;

        CameraLimit();
    }

    private void CameraLimit(bool _OrcPosY = false)
    {
        Vector3 camera = OrcPos;

        if(camera.x - FovX < Left)
            camera.x = Left + FovX;
        else if(camera.x + FovX > Right)
            camera.x = Right - FovX;

        if (_OrcPosY)
            camera.y = OrcPos.y;
    }

    public void Shake(int _CameraID)
    {
        ShakeInfo.StartDelay = 0f;
        ShakeInfo.TotalTime = 3f;
        ShakeInfo.UseTotalTime = true;

        ShakeInfo.Shake = new Vector3(0.2f, 0.2f, 0f);

        ShakeInfo.Dest = ShakeInfo.Shake;
        ShakeInfo.Dir = ShakeInfo.Shake;
        ShakeInfo.Dir.Normalize();

        ShakeInfo.RemainDist = ShakeInfo.Shake.magnitude;
        ShakeInfo.RemainCountDis = float.MaxValue;

        ShakeInfo.Velocity = 8;

        ShakeInfo.Damping = 0.5f;
        ShakeInfo.UseDamping = true;

        ShakeInfo.DampingTime = ShakeInfo.RemainDist / ShakeInfo.Velocity;

        ShakeInfo.Count = 4;
        ShakeInfo.useCount = true;

        StopCoroutine("ShakeCoroutine");
        ResetShakeTr();
        StartCoroutine("ShakeCoroutine");
    }

    IEnumerator ShakeCoroutine()
    {
        cameraShake = true;

        float dt, dist;

        if(ShakeInfo.StartDelay > 0f)
            yield return new WaitForSeconds(ShakeInfo.StartDelay);
        
        while(true)
        {
            dt = Time.fixedDeltaTime;
            dist = dt * ShakeInfo.Velocity;

            if ((ShakeInfo.RemainDist -= dist) > 0)
            {
                ShakeTr.localPosition += ShakeInfo.Dir * dist;

                float rc = transform.position.x - FovX - Left;

                if (rc < 0)
                    ShakeTr.localPosition += new Vector3(-rc, 0, 0);

                rc = Right - (transform.position.x + FovX);

                if (rc < 0)
                    ShakeTr.localPosition += new Vector3(rc, 0, 0);

                CameraLimit(true);

                if (ShakeInfo.useCount)
                {
                    if ((ShakeInfo.RemainCountDis -= dist) < 0)
                    {

                        ShakeInfo.RemainCountDis = float.MaxValue;

                        if (-ShakeInfo.Count < 0)
                            break;
                    }
                }
            }

            else
            {
                if (ShakeInfo.UseDamping)
                {
                    float distdamping = Mathf.Max(
                        ShakeInfo.Damping * ShakeInfo.DampingTime,
                        ShakeInfo.Damping * dt);

                    if (ShakeInfo.Shake.magnitude > distdamping)
                        ShakeInfo.Shake -= ShakeInfo.Dir * distdamping;
                    else
                    {
                        ShakeInfo.useCount = true;
                        ShakeInfo.Count = 1;
                    }
                }

                ShakeTr.localPosition = ShakeInfo.Dest - ShakeInfo.Dir * 
                    (-ShakeInfo.RemainDist);

                float rc = transform.position.x - FovX - Left;

                if (rc < 0)
                    ShakeTr.localPosition += new Vector3(-rc, 0, 0);

                rc = Right - (transform.position.x + FovX);

                if (rc < 0)
                    ShakeTr.localPosition += new Vector3(rc, 0, 0);

                CameraLimit(true);

                ShakeInfo.Shake = -ShakeInfo.Shake;
                ShakeInfo.Dest = -ShakeInfo.Shake;
                ShakeInfo.Dir = -ShakeInfo.Dir;

                float len = ShakeInfo.Shake.magnitude;

                ShakeInfo.RemainCountDis = len + ShakeInfo.RemainDist;
                ShakeInfo.RemainDist += len * 2f;

                ShakeInfo.DampingTime = ShakeInfo.RemainDist / ShakeInfo.Velocity;

                if (ShakeInfo.RemainDist < dist)
                    break;
            }

            if (ShakeInfo.UseTotalTime && (ShakeInfo.TotalTime -= dt) < 0)
                break;

            yield return new WaitForFixedUpdate();
        }

        ResetShakeTr();

        yield break;
       
    }
}

