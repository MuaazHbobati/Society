import "./RegisterForm.css";
import "../../../../shared/styles/forms.css";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { authService } from "../../services/authService";

export default function RegisterForm() {
  const navigate = useNavigate();
  
  // ✅ 1. State لكل حقل على حدة
  const [firstName, setFirstName] = useState("");
  const [fatherName, setFatherName] = useState("");
  const [lastName, setLastName] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [birthDate, setBirthDate] = useState("");
  const [gender, setGender] = useState("");

  // ✅ 2. Flags للتحقق
  const [firstNameTouched, setFirstNameTouched] = useState(false);
  const [fatherNameTouched, setFatherNameTouched] = useState(false);
  const [lastNameTouched, setLastNameTouched] = useState(false);
  const [usernameTouched, setUsernameTouched] = useState(false);
  const [emailTouched, setEmailTouched] = useState(false);
  const [passwordTouched, setPasswordTouched] = useState(false);
  const [confirmPasswordTouched, setConfirmPasswordTouched] = useState(false);
  const [birthDateTouched, setBirthDateTouched] = useState(false);
  const [genderTouched, setGenderTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState("");

  // ✅ 3. دوال التحقق لكل حقل
  const isFirstNameValid = firstName.trim() !== "" && firstName.length >= 2;
  const isFatherNameValid = fatherName.trim() !== "" && fatherName.length >= 2;
  const isLastNameValid = lastName.trim() !== "" && lastName.length >= 2;
  const isUsernameValid = username.trim() !== "" && username.length >= 3;
const isEmailValid = (email) => {
  const lowerEmail = email.toLowerCase();
  return lowerEmail.endsWith('@gmail.com') || lowerEmail.endsWith('@yahoo.com');
};  const isPasswordValid = password.length >= 8 && /[A-Z]/.test(password) && /[0-9]/.test(password);
  const isConfirmPasswordValid = confirmPassword === password;
  const isBirthDateValid = birthDate !== "" && new Date(birthDate) < new Date();
  const isGenderValid = gender === "Male" || gender === "Female";

  // ✅ 4. التحقق الكلي للفورم
  const isFormValid = 
    isFirstNameValid &&
    isFatherNameValid &&
    isLastNameValid &&
    isUsernameValid &&
    isEmailValid &&
    isPasswordValid &&
    isConfirmPasswordValid &&
    isBirthDateValid &&
    isGenderValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    // ✅ 5. تفعيل الـ Touched لكل الحقول
    setFirstNameTouched(true);
    setFatherNameTouched(true);
    setLastNameTouched(true);
    setUsernameTouched(true);
    setEmailTouched(true);
    setPasswordTouched(true);
    setConfirmPasswordTouched(true);
    setBirthDateTouched(true);
    setGenderTouched(true);

    if (!isFormValid) {
      return;
    }

    setLoading(true);
    setApiError("");

    const dataToSend = {
      firstName,
      fatherName,
      lastName,
      username,
      email,
      password,
      birthDate,
      gender
    };

    const result = await authService.register(dataToSend);

    if (result.success) {
      navigate("/login", {
        state: { message: "تم إنشاء الحساب بنجاح! يرجى تسجيل الدخول" },
      });
    } else {
      setApiError(result.error);
    }

    setLoading(false);
  };

  return (
    <div className="register-form-wrapper">
      <div className="form-container">
        <h1 className="form-title">انشاء حساب جديد</h1>

        {apiError && <div className="form-error api-error">{apiError}</div>}

        <form onSubmit={handleSubmit} noValidate>
          <div className="form-grid">
            {/* الاسم الأول */}
            <div className="form-group form-col-half">
              <label>الاسم الأول</label>
              <input
                type="text"
                className={`form-input ${firstNameTouched && !isFirstNameValid ? "error" : ""}`}
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                onBlur={() => setFirstNameTouched(true)}
              />
              {firstNameTouched && !isFirstNameValid && (
                <span className="form-error-text">الاسم الأول مطلوب (حرفين على الأقل)</span>
              )}
            </div>

            {/* اسم الأب */}
            <div className="form-group form-col-half">
              <label>اسم الأب</label>
              <input
                type="text"
                className={`form-input ${fatherNameTouched && !isFatherNameValid ? "error" : ""}`}
                value={fatherName}
                onChange={(e) => setFatherName(e.target.value)}
                onBlur={() => setFatherNameTouched(true)}
              />
              {fatherNameTouched && !isFatherNameValid && (
                <span className="form-error-text">اسم الأب مطلوب (اسم صحيح)</span>
              )}
            </div>

            {/* الكنية */}
            <div className="form-group form-col-half">
              <label>الكنية</label>
              <input
                type="text"
                className={`form-input ${lastNameTouched && !isLastNameValid ? "error" : ""}`}
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                onBlur={() => setLastNameTouched(true)}
              />
              {lastNameTouched && !isLastNameValid && (
                <span className="form-error-text">الكنية مطلوبة (كنية صحيحة)</span>
              )}
            </div>

            {/* اسم المستخدم */}
            <div className="form-group form-col-half">
              <label>اسم المستخدم</label>
              <input
                type="text"
                className={`form-input ${usernameTouched && !isUsernameValid ? "error" : ""}`}
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                onBlur={() => setUsernameTouched(true)}
              />
              {usernameTouched && !isUsernameValid && (
                <span className="form-error-text">اسم المستخدم مطلوب (3 أحرف على الأقل)</span>
              )}
            </div>

            {/* البريد الإلكتروني */}
            <div className="form-group form-col-full">
              <label>البريد الإلكتروني</label>
              <input
                type="email"
                className={`form-input ${emailTouched && !isEmailValid ? "error" : ""}`}
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                onBlur={() => setEmailTouched(true)}
              />
              {emailTouched && !isEmailValid && (
                <span className="form-error-text">البريد الإلكتروني غير صحيح</span>
              )}
            </div>

            {/* كلمة المرور */}
            <div className="form-group form-col-half">
              <label>كلمة المرور</label>
              <input
                type="password"
                className={`form-input ${passwordTouched && !isPasswordValid ? "error" : ""}`}
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                onBlur={() => setPasswordTouched(true)}
              />
              {passwordTouched && !isPasswordValid && (
                <span className="form-error-text">8 أحرف مع حرف كبير ورقم</span>
              )}
            </div>

            {/* تأكيد كلمة المرور */}
            <div className="form-group form-col-half">
              <label>تأكيد كلمة المرور</label>
              <input
                type="password"
                className={`form-input ${confirmPasswordTouched && !isConfirmPasswordValid ? "error" : ""}`}
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                onBlur={() => setConfirmPasswordTouched(true)}
              />
              {confirmPasswordTouched && !isConfirmPasswordValid && (
                <span className="form-error-text">كلمة المرور غير متطابقة</span>
              )}
            </div>

            {/* تاريخ الميلاد */}
            <div className="form-group form-col-half">
              <label>تاريخ الميلاد</label>
              <input
                type="date"
                className={`form-input ${birthDateTouched && !isBirthDateValid ? "error" : ""}`}
                value={birthDate}
                onChange={(e) => setBirthDate(e.target.value)}
                onBlur={() => setBirthDateTouched(true)}
              />
              {birthDateTouched && !isBirthDateValid && (
                <span className="form-error-text">تاريخ ميلاد صحيح مطلوب</span>
              )}
            </div>

            {/* الجنس */}
            <div className="form-group form-col-half">
              <label>الجنس</label>
              <select
                className={`form-input ${genderTouched && !isGenderValid ? "error" : ""}`}
                value={gender}
                onChange={(e) => setGender(e.target.value)}
                onBlur={() => setGenderTouched(true)}
              >
                <option value="">اختر</option>
                <option value="Male">ذكر</option>
                <option value="Female">أنثى</option>
              </select>
              {genderTouched && !isGenderValid && (
                <span className="form-error-text">الرجاء اختيار الجنس</span>
              )}
            </div>
          </div>

          <div>
            <button 
              type="submit" 
              className="form-button" 
              disabled={loading}
            >
              {loading ? "جاري التسجيل..." : "انشاء حساب"}
            </button>

            <Link to="/login" className="form-ahref">
              لدي حساب
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}