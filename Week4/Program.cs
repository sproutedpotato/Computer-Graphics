using System;
using System.IO;
using _20201787_1;

class Program
{
    static void Main()
    {
        string inputFilePath = "input.txt"; // 입력 파일
        string outputFilePath = "output_20201787.txt"; // 출력 파일
        string result = ""; // 파일에 작성할 결과 문자열

        List<string> lines; // 파일을 읽어올 때 사용할 리스트

        if (File.Exists(inputFilePath)) // 만약 파일이 존재한다면
        {
            lines = new List<string>(File.ReadLines(inputFilePath)); // 파일을 읽어와서 리스트에 저장하기

            #region Vector
            if (lines[0].Equals("vector")){ // 첫 줄이 vector이라면
                #region mag
                if (lines[1].Equals("mag")) // 두번째 줄이 mag라면
                {
                    string[] vecs = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 세 번째 줄에 적힌 값을 문자열 배열로 저장
                    Vector vec = new Vector(float.Parse(vecs[0]), float.Parse(vecs[1]), float.Parse(vecs[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성
                    float resultScalar = vec.mag(); // 벡터 길이 계산
                    if(resultScalar % 1 == 0) // 실수형을 반환하는 것을 보여주기 위해 사용
                    {
                        result = $"scalar\n{resultScalar:F1}"; // 결과 문자를 result에 추가
                    }
                    else
                    {
                        result = $"scalar\n{resultScalar}";
                    }   
                }
                #endregion
                #region add
                else if (lines[1].Equals("add")) // 두번째 줄이 add라면
                {
                    string[] vecs_a = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 세 번째 줄에 적힌 값을 문자열 배열로 저장
                    string[] vecs_b = lines[3].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 네 번째 줄에 적힌 값을 문자열 배열로 저장

                    Vector vec_a = new Vector(float.Parse(vecs_a[0]), float.Parse(vecs_a[1]), float.Parse(vecs_a[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성
                    Vector vec_b = new Vector(float.Parse(vecs_b[0]), float.Parse(vecs_b[1]), float.Parse(vecs_b[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성

                    Vector resultVector = vec_a.add(vec_b); // 벡터 덧셈 계산

                    result = $"vector\n";
                    if (resultVector.X % 1 == 0) result += $"{resultVector.X:F1} "; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else  result += $"{resultVector.X} "; 

                    if (resultVector.Y % 1 == 0) result += $"{resultVector.Y:F1} "; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else result += $"{resultVector.Y} ";

                    if (resultVector.Z % 1 == 0) result += $"{resultVector.Z:F1}"; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else result += $"{resultVector.Z}";
                }
                #endregion
                #region inner
                if (lines[1].Equals("inner"))
                {
                    string[] vecs_a = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 세 번째 줄에 적힌 값을 문자열 배열로 저장
                    string[] vecs_b = lines[3].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 네 번째 줄에 적힌 값을 문자열 배열로 저장

                    Vector vec_a = new Vector(float.Parse(vecs_a[0]), float.Parse(vecs_a[1]), float.Parse(vecs_a[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성
                    Vector vec_b = new Vector(float.Parse(vecs_b[0]), float.Parse(vecs_b[1]), float.Parse(vecs_b[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성

                    float resultScalar = vec_a.inner(vec_b); // 벡터 내적 계산

                    if (resultScalar % 1 == 0) // 실수형을 반환하는 것을 보여주기 위해 사용
                    {
                        result = $"scalar\n{resultScalar:F1}"; // 결과 문자를 리스트에 추가
                    }
                    else
                    {
                        result = $"scalar\n{resultScalar}";
                    } 
                }
                #endregion
                #region cross
                else if (lines[1].Equals("cross"))
                {
                    string[] vecs_a = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 세 번째 줄에 적힌 값을 문자열 배열로 저장
                    string[] vecs_b = lines[3].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 네 번째 줄에 적힌 값을 문자열 배열로 저장

                    Vector vec_a = new Vector(float.Parse(vecs_a[0]), float.Parse(vecs_a[1]), float.Parse(vecs_a[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성
                    Vector vec_b = new Vector(float.Parse(vecs_b[0]), float.Parse(vecs_b[1]), float.Parse(vecs_b[2])); // 문자열 배열을 실수형으로 전환 후 벡터 생성

                    Vector resultVector = vec_a.cross(vec_b); // 벡터 외적 계산

                    result = $"vector\n";
                    if (resultVector.X % 1 == 0) result += $"{resultVector.X:F1} "; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else result += $"{resultVector.X} ";

                    if (resultVector.Y % 1 == 0) result += $"{resultVector.Y:F1} "; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else result += $"{resultVector.Y} ";

                    if (resultVector.Z % 1 == 0) result += $"{resultVector.Z:F1}"; // 실수형을 반환하는 것을 보여주기 위해 사용 + 결과 문자를 리스트에 추가
                    else result += $"{resultVector.Z}";
                }
                #endregion
            }
            #endregion
            #region matrix
            else // 첫째줄이 vector가 아니라면
            {
                #region add
                if (lines[1].Equals("add")) // 둘째줄이 add라면
                {
                    string[] nums = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 행렬의 크기 읽어오기
                    int index = 2; // 텍스트 파일에서 읽은 라인 위치 추적을 위한 변수
                    int rows = int.Parse(nums[0]); // 첫 번째 행렬의 행 구하기
                    int cols = int.Parse(nums[1]); // 첫 번째 행렬의 열 구하기

                    string[] nums2 = lines[2 + rows + 1].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 두 번째 행렬의 크기 읽어오기
                    if (nums[0] != nums2[0] || nums[1] != nums2[1]) // 만약 행렬의 사이즈가 같지 않다면
                    {
                        result = $"Not matched!!!";
                        File.WriteAllText(outputFilePath, result); // 오류를 파일에 쓰기
                        Console.WriteLine("Error : Not matched!!!"); // 콘솔에 오류 출력
                        return;
                    }

                    Matrix matrix_a = new Matrix(rows, cols); // 행렬 생성
                    float[,] temp1 = ReadMatrix(lines, index, rows, cols); // 텍스트 파일에서 읽은 행렬을 저장

                    index = 2 + rows + 1; // ReadMatrix로 읽은 라인을 스킵 후 다음 라인을 읽기 위해 준비

                    rows = int.Parse(nums2[0]); // 두 번째 행렬의 행 구하기
                    cols = int.Parse(nums2[1]); // 두 번째 행렬의 열 구하기
                    
                    Matrix matrix_b = new Matrix(rows, cols); // 행렬 생성
                    float[,] temp2 = ReadMatrix(lines, index, rows, cols); // 텍스트 파일에서 읽은 행렬을 저장

                    matrix_a.SetData(temp1); // 행렬에 값을 할당
                    matrix_b.SetData(temp2); // 행렬에 값을 할당
                    
                    result = $"matrix\n{matrix_a.ROW} {matrix_a.COL}\n"; // 결과 타입 및 행렬의 크기를 결과에 저장
                    result += matrix_a.add(matrix_b).PrintMatrix(); // 계산된 행렬을 결과에 저장
                }
                #endregion
                #region mult
                else if (lines[1].Equals("mult")) // 둘째줄이 mult라면
                {
                    string[] nums = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 행렬의 크기 읽어오기
                    int index = 2; // 텍스트 파일에서 읽은 라인 위치 추적을 위한 변수
                    int rows = int.Parse(nums[0]); // 첫 번째 행렬의 행 구하기
                    int cols = int.Parse(nums[1]); // 첫 번째 행렬의 열 구하기

                    string[] nums2 = lines[2 + rows + 1].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 두 번째 행렬의 크기 읽어오기
                    if (nums[1] != nums2[0])
                    {
                        result = $"Not matched!!!";
                        File.WriteAllText(outputFilePath, result); // 오류를 파일에 쓰기
                        Console.WriteLine("Error : Not matched!!!"); // 콘솔에 오류 출력
                        return;
                    }

                    Matrix matrix_a = new Matrix(rows, cols); // 행렬 생성
                    float[,] temp1 = ReadMatrix(lines, index, rows, cols);  // 텍스트 파일에서 읽은 행렬을 저장

                    index = 2 + rows + 1;  // ReadMatrix로 읽은 라인을 스킵 후 다음 라인을 읽기 위해 준비

                    rows = int.Parse(nums2[0]); // 두 번째 행렬의 행 구하기
                    cols = int.Parse(nums2[1]); // 두 번째 행렬의 열 구하기

                    Matrix matrix_b = new Matrix(rows, cols); // 행렬 생성
                    float[,] temp2 = ReadMatrix(lines, index, rows, cols); // 텍스트 파일에서 읽은 행렬을 저장

                    matrix_a.SetData(temp1); // 행렬에 값을 할당
                    matrix_b.SetData(temp2); // 행렬에 값을 할당

                    result = $"matrix\n{matrix_a.COL} {matrix_a.ROW}\n";  // 결과 타입 및 행렬의 크기를 결과에 저장
                    result += matrix_a.mult(matrix_b).PrintMatrix(); // 계산된 행렬을 결과에 저장

                }
                #endregion
                #region trans
                else if (lines[1].Equals("trans")) // 둘째줄이 trans라면
                {
                    string[] nums = lines[2].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 행렬의 크기 읽어오기
                    int index = 2; // 텍스트 파일에서 읽은 라인 위치 추적을 위한 변수
                    int rows = int.Parse(nums[0]); // 행렬의 행 구하기
                    int cols = int.Parse(nums[1]); // 행렬의 열 구하기

                    Matrix matrix_a = new Matrix(rows, cols); // 행렬 생성
                    float[,] temp1 = ReadMatrix(lines, index, rows, cols); // 텍스트 파일에서 읽은 행렬을 저장

                    matrix_a.SetData(temp1); // 행렬에 값을 할당
                    Matrix value = matrix_a.trans(); // 전치 행렬 계산

                    result = $"matrix\n{matrix_a.ROW} {matrix_a.COL}\n"; // 결과 타입 및 행렬의 크기를 결과에 저장
                    result += value.PrintMatrix(); // 계산된 행렬을 결과에 저장
                }
                #endregion
            }
            #endregion

            File.WriteAllText(outputFilePath, result); // 결과를 출력 파일에 작성
        }
        else
        {
            Console.WriteLine("input.txt 파일을 찾을 수 없습니다."); // 파일이 없으면 오류 표시
        }
    }

    public static float[,] ReadMatrix(List<string> lines, int index, int rows, int cols) // 파일의 라인을 읽어 숫자로 변환 후, 배열에 저장하는 함수
    {
        float[,] temp = new float[rows, cols]; // 배열 생성

        for (int i = 0; i < rows; i++)
        {
            index += 1; // 텍스트 파일에서 읽은 라인 위치 추적을 위한 변수
            string[] elements = lines[index].Split(" ", StringSplitOptions.RemoveEmptyEntries); // 읽어온 라인에 적힌 값을 문자열 배열로 저장

            for (int j = 0; j < elements.Length; j++)
            {
                temp[i, j] = float.Parse(elements[j]); // 문자열 배열을 실수형으로 변환 후, 배열에 할당
            }
        }

        return temp; // 배열 반환
    }
}