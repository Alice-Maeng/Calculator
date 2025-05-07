
# C# WinForms 계산기 프로젝트

## 📌 프로젝트 소개

C#과 Windows Forms를 이용한 **기본 계산기 프로그램**을 만들었습니다. <br\>
사칙연산, 소수점, 부호 전환, 백스페이스, 퍼센트 계산, 배경색 변경 등의 기능을 구현하였습니다. 

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
enum operation
{
    plus,
    minus,
    divide,
    multiple,
    equal
}
```

```csharp
private void HandleOperation(operation selectedOp, char symbol)
{
     if (double.TryParse(text, out a)) // 3+과 같은 숫자+연산자 표시를 위해 필요
     {
         op = selectedOp; //연산자 선택
         textBox_result.Text += symbol; // 연산자 추가
         result_Num = false;
     }
}
```

- `HandleOperation()`은 +, -, ×, ÷ 클릭 시 실행되며 현재 입력값 검증 후 연산자와 피연산자를 저장합니다.

---

### 2. 숫자 버튼 처리 (`AppendNumber`)
`AppendNumber` 메서드는 숫자 버튼을 클릭할 때마다 해당 숫자를 `RichTextBox`에 추가합니다. 
결과값을 표시한 후 새로운 숫자를 입력하려는 경우 화면을 초기화합니다.

```csharp
private void AppendNumber(string num)
{
    if (result_Num)
    {
        richTextBox1.Text = "";
        result_Num = false;
    }
    richTextBox1.Font = new Font("Arial", 14);
    richTextBox1.Text += num;
}
```

### 3. 연산자 처리 (`HandleOperation`)
`HandleOperation` 메서드는 사용자가 연산자 버튼을 클릭했을 때, 입력된 텍스트가 유효한지 확인한 후, 연산자를 처리하고 텍스트에 해당 연산자를 추가합니다. 연산자 입력이 잘못된 위치에 있을 경우 에러 메시지를 표시합니다.

```csharp
private void HandleOperation(operation selectedOp, char symbol)
{
    string text = richTextBox1.Text;

    // 빈칸 / 연산자로 끝나는 경우 오류 처리
    if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
    {
        ShowError("연산자를 입력할 수 없는 위치입니다.");
        return;
    }

    if (double.TryParse(text, out a))
    {
        op = selectedOp;
        richTextBox1.Text += symbol; 
        result_Num = false;
    }
    else
    {
        ShowError("숫자를 올바르게 입력해주세요.");
    }
}
```

### 4. `=` 버튼 클릭 시 연산 수행 (`button_eq_Click`)
`button_eq_Click` 메서드는 사용자가 `=` 버튼을 클릭했을 때, 입력된 수식에 대해 연산을 수행하고 결과를 화면에 표시합니다. 연산자는 `op` 변수에 저장된 값에 따라 다르게 처리됩니다.

```csharp
private void button_eq_Click(object sender, EventArgs e)
{
    string text = richTextBox1.Text;
    result_Num = true;

    // 잘못된 입력 체크
    if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())))
    {
        ShowError("연산할 수 없습니다.");
        return;
    }

    string[] parts = null;
    char operatorSymbol = ' '; 

    switch (op)
    {
        case operation.plus:
            parts = text.Split('+');
            operatorSymbol = '+';  
            break;
        case operation.minus:
            parts = text.Split('-');
            operatorSymbol = '-';  
            break;
        case operation.multiple:
            parts = text.Split('*');
            operatorSymbol = '*';  
            break;
        case operation.divide:
            parts = text.Split('/');
            operatorSymbol = '/';  
            break;
    }

    if (parts == null || parts.Length != 2 || !double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b))
    {
        ShowError("올바른 계산식이 아닙니다.");
        return;
    }

    switch (op)
    {
        case operation.plus:
            result = a + b; 
            break;
        case operation.minus:
            result = a - b; 
            break;
        case operation.multiple:
            result = a * b; 
            break;
        case operation.divide:
            if (b == 0)
            {
                MessageBox.Show("0으로 나눌 수 없습니다.");
                return;
            }
            result = a / b; 
            break;
    }

    richTextBox1.Clear();
    richTextBox1.AppendText($"{a} {operatorSymbol} {b} = {result}");
    a = result;
}
```

### 5. 부호 전환 처리 (`button_pm_Click`)
`button_pm_Click` 메서드는 부호 전환 버튼을 클릭했을 때, 현재 입력된 숫자의 부호를 반전시킵니다.

```csharp
private void button_pm_Click(object sender, EventArgs e)
{
    string text = richTextBox1.Text;
    if (string.IsNullOrEmpty(text) || operators.Any(op => text.LastIndexOf(op) > 0) || text.EndsWith("."))
    {
        ShowError("부호를 바꿀 수 없습니다.");
        return;
    }

    if (double.TryParse(text, out double value))
    {
        richTextBox1.Text = (-value).ToString();
    }
}
```



---

## 📷 UI 미리보기



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

- 이름: 맹승연

