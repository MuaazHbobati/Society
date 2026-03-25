import "./RegisterForm.css";
import "../../../../shared/styles/forms.css";
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { authService } from "../../services/authService";
import { getAllPrograms } from  "../../../partners/services/programService.js";

export default function RegisterForm() {
  const navigate = useNavigate();

  // ===== State لكل حقل =====
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [svuMail, setSvuMail] = useState("");
  const [programId, setProgramId] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [birthDate, setBirthDate] = useState("");
  const [gender, setGender] = useState("");

  // ===== State للبرامج =====
  const [programs, setPrograms] = useState([]);
  const [loadingPrograms, setLoadingPrograms] = useState(false);

  // ===== Flags للتحقق =====
  const [firstNameTouched, setFirstNameTouched] = useState(false);
  const [lastNameTouched, setLastNameTouched] = useState(false);
  const [usernameTouched, setUsernameTouched] = useState(false);
  const [emailTouched, setEmailTouched] = useState(false);
  const [svuMailTouched, setSvuMailTouched] = useState(false);
  const [programIdTouched, setProgramIdTouched] = useState(false);
  const [passwordTouched, setPasswordTouched] = useState(false);
  const [confirmPasswordTouched, setConfirmPasswordTouched] = useState(false);
  const [birthDateTouched, setBirthDateTouched] = useState(false);
  const [genderTouched, setGenderTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState("");

  // ===== جلب البرامج عند تحميل الصفحة =====
  useEffect(() => {
    const fetchPrograms = async () => {
      setLoadingPrograms(true);
      try {
        const data = await getAllPrograms();
        setPrograms(Array.isArray(data) ? data : []);
      } catch (error) {
        console.error("Error fetching programs:", error);
        setPrograms([]);
      } finally {
        setLoadingPrograms(false);
      }
    };
    fetchPrograms();
  }, []);

  // ===== دوال التحقق لكل حقل =====
  const isFirstNameValid = firstName.trim() !== "" && firstName.length >= 2;
  const isLastNameValid = lastName.trim() !== "" && lastName.length >= 2;
  const isUsernameValid = username.trim() !== "" && username.length >= 3 && /^[a-zA-Z0-9_]+$/.test(username);
  const isEmailValid = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  const isSvuMailValid = svuMail.toLowerCase().endsWith("@svuonline.org") && /^[a-z0-9_]+@svuonline\.org$/.test(svuMail.toLowerCase());
  const isProgramIdValid = programId !== "" && programId !== null;
  const isPasswordValid = password.length >= 8 && /[A-Z]/.test(password) && /[0-9]/.test(password);
  const isConfirmPasswordValid = confirmPassword === password;
  const isBirthDateValid = birthDate !== "" && new Date(birthDate) < new Date();
  const isGenderValid = gender === "Male" || gender === "Female";

  // ===== التحقق الكلي للفورم =====
  const isFormValid =
    isFirstNameValid &&
    isLastNameValid &&
    isUsernameValid &&
    isEmailValid &&
    isSvuMailValid &&
    isProgramIdValid &&
    isPasswordValid &&
    isConfirmPasswordValid &&
    isBirthDateValid &&
    isGenderValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    // تفعيل الـ Touched لكل الحقول
    setFirstNameTouched(true);
    setLastNameTouched(true);
    setUsernameTouched(true);
    setEmailTouched(true);
    setSvuMailTouched(true);
    setProgramIdTouched(true);
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
      lastName,
      username,
      email,
      svuMail,
      programId: parseInt(programId),
      password,
      birthDate,
      gender,
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
                placeholder="مثال: Mohammad"
              />
              {firstNameTouched && !isFirstNameValid && (
                <span className="form-error-text">الاسم الأول مطلوب (حرفين على الأقل)</span>
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
                placeholder="مثال: Al Saeed"
              />
              {lastNameTouched && !isLastNameValid && (
                <span className="form-error-text">الكنية مطلوبة (حرفين على الأقل)</span>
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
                placeholder="مثال: Mohammad_1234"
              />
              {usernameTouched && !isUsernameValid && (
                <span className="form-error-text">اسم المستخدم مطلوب (3-20 حرف، أحرف وأرقام و _ فقط)</span>
              )}
            </div>

            {/* البريد الإلكتروني الشخصي */}
            <div className="form-group form-col-half">
              <label>البريد الإلكتروني</label>
              <input
                type="email"
                className={`form-input ${emailTouched && !isEmailValid ? "error" : ""}`}
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                onBlur={() => setEmailTouched(true)}
                placeholder="مثال: MohammadAlSaeed@gmail.com"
              />
              {emailTouched && !isEmailValid && (
                <span className="form-error-text">البريد الإلكتروني غير صحيح</span>
              )}
            </div>

            {/* البريد الجامعي SVU */}
            <div className="form-group form-col-half">
              <label>البريد الجامعي (SVU)</label>
              <input
                type="email"
                className={`form-input ${svuMailTouched && !isSvuMailValid ? "error" : ""}`}
                value={svuMail}
                onChange={(e) => setSvuMail(e.target.value)}
                onBlur={() => setSvuMailTouched(true)}               
              />
              {svuMailTouched && !isSvuMailValid && (
                <span className="form-error-text">البريد الجامعي يجب أن يكون صحيح</span>
              )}
            </div>

            {/* البرنامج */}
            <div className="form-group form-col-full">
              <label>البرنامج</label>
              <select
                className={`form-input ${programIdTouched && !isProgramIdValid ? "error" : ""}`}
                value={programId}
                onChange={(e) => setProgramId(e.target.value)}
                onBlur={() => setProgramIdTouched(true)}
                disabled={loadingPrograms}
              >
                <option value="">-- اختر البرنامج --</option>
                {programs.map((program) => (
                  <option key={program.id} value={program.id}>
                    {program.name}
                  </option>
                ))}
              </select>
              {programIdTouched && !isProgramIdValid && (
                <span className="form-error-text">الرجاء اختيار البرنامج</span>
              )}
              {loadingPrograms && (
                <span className="loading-text">جاري تحميل البرامج...</span>
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
                placeholder="**********"
              />
              {passwordTouched && !isPasswordValid && (
                <span className="form-error-text">8 أحرف مع حرف كبير ورقم على الأقل</span>
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
                placeholder="**********"
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
              className="normalButton"
              disabled={loading}
              style={{ width: "100%", marginBottom: "20px" }}
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