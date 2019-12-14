using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace DX.Tools
{
    /// <summary>
    /// 贯穿于我的工程各种静态方法
    /// </summary>

    public static class MMMaths 
	{
        /// <summary>
        /// 接受一个Vector3并将其变成一个Vector2
        /// </summary>
        /// <returns>The vector2.</returns>
        /// <param name="target">将Vector3变成Vector2。</param>
        public static Vector2 Vector3ToVector2 (Vector3 target) 
		{
			return new Vector2(target.x, target.y);
		}

        /// <summary>
        /// 取一个Vector2并将其转换为z值为空的Vector3
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="target">将Vector2变成Vector3。</param>
        public static Vector3 Vector2ToVector3 (Vector2 target) 
		{
			return new Vector3(target.x, target.y, 0);
		}

        /// <summary>
        /// 取一个Vector2并将其转换为具有指定z值的Vector3
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="target">将Vector2变成Vector3。</param>
        /// <param name="newZValue">新的Z值。</param>
        public static Vector3 Vector2ToVector3 (Vector2 target, float newZValue) 
		{
			return new Vector3(target.x, target.y, newZValue);
		}

        /// <summary>
        /// Vector3返回f四舍五入到最接近的整数。如果数字以.5结尾，那么它位于两个整数之间的中间，其中一个是偶数，另一个是奇数，则返回偶数。
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="vector">Vector.</param>
        public static Vector3 RoundVector3 (Vector3 vector)
		{
			return new Vector3 (Mathf.Round (vector.x), Mathf.Round (vector.y), Mathf.Round (vector.z));
		}

        /// <summary>
        /// 从2个定义的vector3中返回一个随机vector3。
		/// </summary>
		/// <returns>The vector3.</returns>
		/// <param name="min">最小值</param>
		/// <param name="max">最大值</param>
		public static Vector3 RandomVector3(Vector3 minimum, Vector3 maximum)
		{
			return new Vector3(UnityEngine.Random.Range(minimum.x, maximum.x), 
											 UnityEngine.Random.Range(minimum.y, maximum.y), 
											 UnityEngine.Random.Range(minimum.z, maximum.z));
		}

        /// <summary>
        /// 围绕给定的轴旋转点。
        /// </summary>
        /// <returns>The new point position.</returns>
        /// <param name="point">旋转点。</param>
        /// <param name="pivot">枢轴的位置。</param>
		/// <param name="angle">旋转角度。</param>
		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle) 
		{			
			angle = angle*(Mathf.PI/180f);
			var rotatedX = Mathf.Cos(angle) * (point.x - pivot.x) - Mathf.Sin(angle) * (point.y-pivot.y) + pivot.x;
			var rotatedY = Mathf.Sin(angle) * (point.x - pivot.x) + Mathf.Cos(angle) * (point.y - pivot.y) + pivot.y;
			return new Vector3(rotatedX,rotatedY,0);		
				}

        /// <summary>
        /// 围绕给定的轴旋转点。
        /// </summary>
        /// <returns>The new point position.</returns>
        /// <param name="point">旋转点。</param>
        /// <param name="pivot">枢轴的位置。</param>
        /// <param name="angles">作为Vector3的角度.</param>
        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle) 
		{
            //得到从点到枢轴的点方向
            Vector3 direction = point - pivot;
            //旋转方向
            direction = Quaternion.Euler(angle) * direction;
            //确定旋转点的位置
            point = direction + pivot;
            return point; 
		}

        /// <summary>
        ///  围绕给定的轴旋转点。
		/// </summary>
		/// <returns>The new point position.</returns>
		/// <param name="point">旋转点。</param>
		/// <param name="pivot">枢纽的位置</param>
		/// <param name="angles">作为Vector3的角度</param>
		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion quaternion) 
		{
            //得到从点到枢轴的点方向
            Vector3 direction = point - pivot;
            //旋转方向
            direction = quaternion * direction;
            //确定旋转点的位置
            point = direction + pivot; 
		   	return point; 
		 }

        /// <summary>
        /// 将vector2旋转指定角度（以度为单位）并返回
        /// </summary>
        /// <returns>The rotated Vector2.</returns>
        /// <param name="vector">要旋转的向量。</param>
        /// <param name="angle">角度（以度为单位）.</param>
        public static Vector2 RotateVector2(Vector2 vector, float angle) {
			if (angle == 0)
			{
				return vector;
			}
			float sinus = Mathf.Sin(angle * Mathf.Deg2Rad);
			float cosinus = Mathf.Cos(angle * Mathf.Deg2Rad);

			float oldX = vector.x;
			float oldY = vector.y;
			vector.x = (cosinus * oldX) - (sinus * oldY);
			vector.y = (sinus * oldX) + (cosinus * oldY);
			return vector;
		}

        /// <summary>
        /// 以360°比例计算并返回两个向量之间的角度
        /// </summary>
        /// <returns>The <see cref="System.Single"/>.</returns>
        /// <param name="vectorA">Vector a.</param>
        /// <param name="vectorB">Vector b.</param>
        public static float AngleBetween(Vector2 vectorA, Vector2 vectorB)
		{
			float angle = Vector2.Angle(vectorA, vectorB);
			Vector3 cross = Vector3.Cross(vectorA, vectorB);

			if (cross.z > 0)
			{
				angle = 360 - angle;
			}

			return angle;
		}

        /// <summary>
        /// 返回点和线之间的距离。
		/// </summary>
		/// <returns>The between point and line.</returns>
		/// <param name="point">Point.</param>
		/// <param name="lineStart">Line start.</param>
		/// <param name="lineEnd">Line end.</param>
		public static float DistanceBetweenPointAndLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
		{
			return Vector3.Magnitude(ProjectPointOnLine(point, lineStart, lineEnd) - point);
		}

        /// <summary>
        /// 将点投影在直线上（垂直）并返回投影点
        /// </summary>
        /// <returns>The point on line.</returns>
        /// <param name="point">Point.</param>
        /// <param name="lineStart">Line start.</param>
        /// <param name="lineEnd">Line end.</param>
        public static Vector3 ProjectPointOnLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
		{
			Vector3 rhs = point - lineStart;
			Vector3 vector2 = lineEnd - lineStart;
			float magnitude = vector2.magnitude;
			Vector3 lhs = vector2;
			if (magnitude > 1E-06f)
			{
				lhs = (Vector3)(lhs / magnitude);
			}
			float num2 = Mathf.Clamp(Vector3.Dot(lhs, rhs), 0f, magnitude);
			return (lineStart + ((Vector3)(lhs * num2)));
		}

        /// <summary>
        /// 返回传入的所有int参数的总和
        /// </summary>
        /// <param name="thingsToAdd">Things to add.</param>
        public static int Sum(params int[] thingsToAdd)
		{
			int result=0;
			for (int i = 0; i < thingsToAdd.Length; i++)
			{
				result += thingsToAdd[i];
			}
			return result;
		}

        /// <summary>
        /// 返回骰子指定边数的结果
        /// </summary>
        /// <returns>The result of the dice roll.</returns>
        /// <param name="numberOfSides">骰子的边数.</param>
        public static int RollADice(int numberOfSides)
		{
			return (UnityEngine.Random.Range(1,numberOfSides));
		}

        /// <summary>
        /// 根据X％的机会返回随机成功。
        ///示例：我有20％的机会做X，Chance（20）> true，是的！
		/// </summary>
		/// <param name="percent">Percent of chance.</param>
		public static bool Chance(int percent)
		{
			return (UnityEngine.Random.Range(0,100) <= percent);
		}

        /// <summary>
        ///  从“起点”到“终点”移动指定的数量并返回相应的值
        /// </summary>
        /// <param name="from">起.</param>
        /// <param name="to">终.</param>
        /// <param name="amount">量.</param>
        public static float Approach(float from, float to, float amount)
		{
			if (from < to)
			{
				from += amount;
				if (from > to)
				{
					return to;
				}
			}
			else
			{
				from -= amount;
				if (from < to)
				{
					return to;
				}
			}
			return from;
		}


        /// <summary>
        /// 将间隔[A，B] 中的值x重新映射为间隔[C，D]中的比例值
        /// </summary>
        /// <param name="x">要重映射的值</param>
        /// <param name="A">包含x值的区间[A，B] 的最小界限</param>
        /// <param name="B">包含x值的区间[A，B] 的最大界限</param>
        /// <param name="C">目标间隔的最小界限[C，D]</param>
        /// <param name="D">目标间隔的最大界限[C，D]</param>
        public static float Remap(float x, float A, float B, float C, float D)
		{
			float remappedValue = C + (x-A)/(B-A) * (D - C);
			return remappedValue;
		}

        /// <summary>
        /// 返回输入的值从给定的集合中最接近的
        /// </summary>
        /// <param name="value"></param>
        /// <param name="possibleValues"></param>
        /// <returns></returns>
		public static float RoundToClosest(float value, float[] possibleValues)
		{
			if (possibleValues.Length == 0) 
			{
				return 0f;
			}

			float closestValue = possibleValues[0];

			foreach (float possibleValue in possibleValues)
			{
				if (Mathf.Abs(closestValue - value) > Mathf.Abs(possibleValue - value))
				{
					closestValue = possibleValue;
				}	
			}
			return closestValue;

		}
	}
}