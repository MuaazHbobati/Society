import "./LoginForm.css";
import "../../../../shared/styles/forms.css";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { authService } from "../../services/authService";

export default function LoginForm() {
  const navigate = useNavigate();

  // State للحقول
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // Flags للتحقق
  const [emailTouched, setEmailTouched] = useState(false);
  const [passwordTouched, setPasswordTouched] = useState(false);

  const [loading, setLoading] = useState(false);
  const [apiError, setApiError] = useState("");

  // ✅ التحقق من صحة الإيميل (Gmail أو Yahoo)
  const isEmailValid = () => {
    const lowerEmail = email.toLowerCase();
    return (
      lowerEmail.endsWith("@gmail.com") || lowerEmail.endsWith("@yahoo.com")
    );
  };

  const isPasswordValid = password.trim() !== "";
  const isFormValid = isEmailValid() && isPasswordValid;

  const handleSubmit = async (e) => {
    e.preventDefault();

    setEmailTouched(true);
    setPasswordTouched(true);

    if (!isFormValid) {
      return;
    }

    setLoading(true);
    setApiError("");

    const result = await authService.login({ email, password });

    if (result.success) {
      // ✅ بعد تسجيل الدخول، نوجه المستخدم للـ Dashboard
      navigate("/");
    } else {
      setApiError(result.error);
    }

    setLoading(false);
  };

  return (
    <div className="login-form-wrapper">
      <div className="form-container">
        <h1 className="form-title">تسجيل الدخول</h1>

        {apiError && <div className="form-error api-error">{apiError}</div>}

        <form onSubmit={handleSubmit} noValidate>
          {/* البريد الإلكتروني */}
          <div className="form-group">
            <label>البريد الإلكتروني</label>
            <input
              type="email"
              className={`form-input ${emailTouched && !isEmailValid() ? "error" : ""}`}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              onBlur={() => setEmailTouched(true)}
              placeholder="example@gmail.com"
            />
            {emailTouched && !isEmailValid() && (
              <span className="form-error-text">
                البريد الإلكتروني غير صحيح (Gmail أو Yahoo فقط)
              </span>
            )}
          </div>

          {/* كلمة المرور */}
          <div className="form-group">
            <label>كلمة المرور</label>
            <input
              type="password"
              className={`form-input ${passwordTouched && !isPasswordValid ? "error" : ""}`}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              onBlur={() => setPasswordTouched(true)}
              placeholder="********"
            />
            {passwordTouched && !isPasswordValid && (
              <span className="form-error-text">كلمة المرور مطلوبة</span>
            )}
          </div>

          <div>
            <button 
              type="submit" 
              className="form-button" 
              disabled={loading}
            >
              {loading ? "جاري تسجيل الدخول..." : "دخول"}
            </button>

            <Link to="/register" className="form-ahref">
              ليس لديك حساب؟ سجل الآن
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}