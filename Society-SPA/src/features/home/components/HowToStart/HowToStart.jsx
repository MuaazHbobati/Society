import "./HowToStart.css";
import { FaUserCircle, FaHandshake, FaComments } from "react-icons/fa";
import HowToStartCard from "../../../../shared/components/Cards/HowToStartCard/HowToStartCard.jsx";
import { Link } from "react-router-dom";
export default function HowToStart() {
  const steps = [
    {
      icon: <FaUserCircle size={40} />,
      stepNumber: "1",
      title: "هويتك الرقمية",
      description:
        "ابدأ ببناء ملف شخصي احترافي يعكس هويتك الأكاديمية: اسمك، تخصصك، مهاراتك، اهتماماتك، وروابط تواجدك الرقمي ومعرض أعمالك.",
      color: "var(--blue)",
    },
    {
      icon: <FaHandshake size={40} />,
      stepNumber: "2",
      title: "نظام الشركاء",
      description:
        "انشر طلب مشروع (العدد المطلوب، المادة، وصف المشروع) ويقترح النظام الطلاب الأكثر توافقاً مع معاييرك، مع إشعار فور اكتمال الفريق.",
      color: "var(--blue-dark)",
    },
    {
      icon: <FaComments size={40} />,
      stepNumber: "3",
      title: "تفاعل هادف",
      description:
        "شارك في نقاشات أكاديمية جادة، منشورات منظمة، تعليقات مثمرة، ضمن مواضيع تقنية بحت بعيداً عن الفوضى.",
      color: "var(--blue)",
    },
  ];

  return (
    <div className="how-to-start-container" id="how-to-start">
      <div className="how-to-start-content">
        <h2 className="how-to-start-title">كيف تبدأ مع Society؟</h2>

        <div className="steps-container">
          {steps.map((step, index) => (
            <HowToStartCard
              key={index}
              icon={step.icon}
              stepNumber={step.stepNumber}
              title={step.title}
              description={step.description}
              color={step.color}
            />
          ))}
        </div>

        <div className="cta-container">
          <Link to="/register">
            <button className="normalButton how-to-start-btn">
              ابدأ الآن!
            </button>
          </Link>
        </div>
      </div>
    </div>
  );
}
