using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20201787_1
{
    public class Matrix
    {
        private float[,] ele { get; set; } // 행렬 저장을 위한 변수
        public float[,] ELE { get { return ele; } set { ele = value; } } // 외부에서 접근 가능한 행렬
        private int num_of_rows; // 행의 수
        public int ROW { get { return num_of_rows; } } // 외부에서 행을 반환받기 위해 사용
        private int num_of_columns; // 열의 수
        public int COL { get { return num_of_columns; } } // 외부에서 열을 반환받기 위해 사용
        public Matrix(int a, int b) // 행렬 생성자
        {
            this.num_of_rows = a;
            this.num_of_columns = b;
            ele = new float[a, b];
        }
        public void SetData(float[,] data) // 배열을 행렬에 할당하는 함수
        {
            for (int i = 0; i < num_of_rows; i++)
            {
                for (int j = 0; j < num_of_columns; j++)
                {
                    this.ele[i, j] = data[i, j]; // 인자로 받은 배열의 값을 행렬에 할당
                }
            }
        }

        public string PrintMatrix() // 행렬을 결과에 저장하는 함수
        {
            string result = "";
            float[,] temp = this.ELE;
            for (int i = 0; i < this.num_of_rows; i++)
            {
                for (int j = 0; j < this.num_of_columns; j++)
                {
                    if (temp[i, j] % 1 == 0) // float형으로 반환함을 보이기 위하여 사용
                    {
                        result = result + $"{temp[i, j]:F1}"; // 행렬을 결과에 저장
                    }
                    else
                    {
                        result = result + $"{temp[i, j]}";
                    }

                    if (j != this.num_of_columns - 1)
                    {
                        result += " "; // 행의 끝이 아니라면 " "를 결과에 추가
                    }
                }
                result += "\n";
            }

            return result;
        }

        public Matrix add(Matrix b) // 행렬 덧셈 함수
        {

            float[,] result = new float[this.ROW, this.COL]; // 크기에 맞는 배열 생성

            for (int i = 0; i < this.ROW; i++)
            {
                for (int j = 0; j < this.COL; j++)
                {
                    result[i, j] = this.ELE[i, j] + b.ELE[i, j]; // 행렬 덧셈 계산
                }
            }

            Matrix matrix = new Matrix(this.ROW, this.COL); // 행렬 생성
            matrix.SetData(result); // 행렬에 값을 할당

            return matrix;
        }

        public Matrix mult(Matrix b) // 행렬 곱셈 함수
        {
            float[,] result = new float[this.ROW, b.COL]; // 크기에 맞는 배열 생성

            for (int i = 0; i < this.ROW; i++)
            {
                for (int j = 0; j < b.COL; j++)
                {
                    result[i, j] = 0; // C#의 경우 0으로 기본적으로 초기화가 되지만, 덧셈이기에 혹시 모를 변수를 방지하기 위해 0으로 초기화
                    for (int k = 0; k < this.COL; k++)
                    {
                        result[i, j] += this.ELE[i, k] * b.ELE[k, j]; // 행렬 곱셈 계산 후 결과 배열에 덧셈
                    }
                }
            }

            Matrix matrix = new Matrix(this.ROW, b.COL); // 행렬 생성
            matrix.SetData(result); // 행렬에 값을 할당

            return matrix;
        }

        public Matrix trans() // 전치 행렬 생성 함수
        {
            float[,] result = new float[this.COL, this.ROW]; // 크기에 맞는 배열 생성
            float[,] matrix = this.ELE; // 자신 받아오기

            for (int i = 0; i < this.ROW; i++)
            {
                for (int j = 0; j < this.COL; j++)
                {
                    result[j, i] = matrix[i, j]; // 기존 행렬의 행과 열을 바꾸어 저장
                }
            }

            Matrix returnValue = new Matrix(this.COL, this.ROW); // 행렬 생성
            returnValue.SetData(result); // 행렬에 값을 할당

            return returnValue;
        }
    }  
}
