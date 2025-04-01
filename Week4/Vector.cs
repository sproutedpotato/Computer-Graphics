using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201787_1
{
    public class Vector
    {
        private float x { get; set; } // x 좌표
        public float X { get { return x; } } // 외부에서 접근 가능한 x좌표
        private float y { get; set; } // y 좌표
        public float Y { get { return y; } } // 외부에서 접근 가능한 y좌표
        private float z { get; set; } // z 좌표
        public float Z { get { return z; } } // 외부에서 접근 가능한 z좌표

        public Vector(float x, float y, float z) // 벡터 생성자
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float mag() // 길이 계산 함수
        {
            decimal x = (decimal)this.X; // 정확한 계산을 위해 decimal 사용
            decimal y = (decimal)this.Y;
            decimal z = (decimal)this.Z;

            decimal result = (decimal)Math.Sqrt((double)((x * x) + (y * y) + (z * z))); // root(x^2 + y^2 + z^2) 계산

            result = Math.Round(result, 2, MidpointRounding.AwayFromZero); // 소수점 셋째 자리에서 반올림 : 숫자가 5일 때 반올림 하기 위해 AwayFromZero 사용
            return (float)result; // 결과 반환
        }

        public Vector add(Vector b) // 벡터 덧셈 함수
        {
            // 정확한 계산을 위해 decimal 사용
            decimal vec_x = Math.Round((decimal)(this.X + b.X), 2, MidpointRounding.AwayFromZero); // 벡터 덧셈 계산
            decimal vec_y = Math.Round((decimal)(this.Y + b.Y), 2, MidpointRounding.AwayFromZero); // 소수점 셋째 자리에서 반올림
            decimal vec_z = Math.Round((decimal)(this.Z + b.Z), 2, MidpointRounding.AwayFromZero); // 숫자가 5일 때 반올림 하기 위해 AwayFromZero 사용

            Vector result = new Vector((float)vec_x, (float)vec_y, (float)vec_z);

            return result;
        }

        public float inner(Vector b) // 벡터 내적 함수
        {
            decimal result = Math.Round((decimal)(this.X * b.X + this.Y * b.Y + this.Z * b.Z), 2, MidpointRounding.AwayFromZero);
            // 내적 계산 후 반올림

            return (float)result;
        }

        public Vector cross(Vector b) // 벡터 외적 함수
        {
            // 정확한 계산을 위해 decimal 사용
            decimal vec_x = Math.Round((decimal)(this.Y * b.Z - this.Z * b.Y), 2, MidpointRounding.AwayFromZero); // 벡터 외적 계산
            decimal vec_y = Math.Round((decimal)(this.Z * b.X - this.X * b.Z), 2, MidpointRounding.AwayFromZero);
            decimal vec_z = Math.Round((decimal)(this.X * b.Y - this.Y * b.X), 2, MidpointRounding.AwayFromZero);

            Vector result = new Vector((float)vec_x, (float)vec_y, (float)vec_z);

            return result;
        }
    }
}
