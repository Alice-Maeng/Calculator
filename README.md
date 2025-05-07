
# C# WinForms 계산기 프로젝트

## 📌 프로젝트 개요

이 프로젝트는 C#과 Windows Forms를 이용한 **기본 계산기 프로그램**입니다.  
사칙연산, 소수점, 부호 전환, 백스페이스, 퍼센트 계산, 배경색 변경 등의 기능을 포함하고 있으며, 사용자 친화적인 예외 처리도 구현되어 있습니다.

---

## 🧩 구현한 기능 소개

| 기능         | 설명 |
|--------------|------|
| 숫자 입력     | 0~9 버튼을 통해 숫자를 입력할 수 있습니다. |
| 사칙연산     | +, -, ×, ÷ 버튼을 통해 기본 연산 수행 |
| 소수점 처리  | 소수점(.) 입력 및 중복 방지 |
| ± 부호 전환 | 현재 수의 부호를 변경 |
| % 퍼센트     | 현재 수를 100으로 나눈 값 계산 |
| 초기화 (C)   | 모든 입력 값 초기화 |
| 삭제         | 마지막 입력 문자 삭제 (Backspace) |
| 색상 변경   | 메뉴에서 Red, Blue, Gray, Pink 배경색 설정 가능 |
| 예외처리     | 잘못된 입력(연산자 중복, 소수점 오류 등)에 대해 MessageBox로 안내 |

---

## 🛠 설계 방법 및 사용한 기술

- **개발 환경**: Visual Studio / .NET Framework
- **프로그래밍 언어**: C#
- **GUI 프레임워크**: Windows Forms (WinForms)

### 설계 구조 요약

- **`Form1.cs`**: 전체 로직을 관리하는 메인 폼
  - **이벤트 중심 설계**: 버튼 클릭 이벤트마다 대응 함수 호출
  - **로직 분리**: 숫자 입력, 연산 처리, 오류 처리 등으로 기능 모듈화
- **Enum 사용**: `operation` 열거형을 통해 연산자 상태 관리
- **예외 처리 강화**: 입력값 끝이 연산자이거나 소수점 중복 등 다양한 예외 상황 처리

---

## 🔍 코드의 주요 부분 설명

### 1. 연산 처리 (핵심 로직)

```csharp
enum operation { plus, minus, divide, multiple, equal }
operation op;
double a, b, result;
```

```csharp
private void HandleOperation(operation selectedOp, char symbol)
{
    if (조건문을 통해 입력 검증)
    {
        op = selectedOp;
        textBox_result.Text += symbol;
        result_Num = false;
    }
}
```

- `HandleOperation()`은 +, -, ×, ÷ 클릭 시 실행되며 현재 입력값 검증 후 연산자와 피연산자를 저장합니다.

---

### 2. = 버튼 처리

```csharp
private void button_eq_Click(object sender, EventArgs e)
{
    입력값을 분리하고 (Split),
    double.TryParse()로 a, b 파싱 후 연산 수행
    연산 결과를 textBox에 표시
}
```

- 연산자 종류에 따라 분기(`switch-case`)하여 두 수를 계산합니다.

---

### 3. 예외 처리

```csharp
private void ShowError(string message = "잘못된 입력입니다.")
{
    MessageBox.Show(message);
    result_Num = false;
}
```

- 소수점 중복, 잘못된 연산자 입력 등 다양한 에러 상황에 대비하여 `MessageBox` 팝업으로 사용자에게 알림을 줍니다.

---

## 📷 UI 미리보기

> *(스크린샷을 추가하면 좋습니다)*  
> ![calculator ui preview](https://example.com/screenshot.png)

---

## 🚀 실행 방법

1. Visual Studio에서 프로젝트 열기
2. `Form1.cs`에서 디자인 및 로직 확인
3. 실행(F5) 후 WinForms 기반 계산기 사용

---

## ✨ 향후 개선 아이디어

- 연산 우선순위 처리 (예: 2 + 3 × 4)
- 연속 계산 처리 (예: 2 + 3 = + 4 =)
- 계산 내역 저장 기능
- 괄호 연산 구현
- 키보드 입력 대응

---

## 🧑‍💻 개발자

- 이름: *(여기에 본인 이름 작성)*
- GitHub: *(옵션)*
- 이메일: *(옵션)*
