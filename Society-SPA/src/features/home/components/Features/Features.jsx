import "./Features.css";
import FeaturesCard from "../../../../shared/components/Cards/FeaturesCard/FeaturesCard.jsx";
import { FaUserGraduate, FaHandshake, FaComments, FaUsers, FaRocket } from 'react-icons/fa';
import { useEffect, useRef } from "react";

export default function Features() {
  const sectionRef = useRef(null);

  useEffect(() => {
    const currentSection = sectionRef.current;
    
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            const cards = document.querySelectorAll(".featurescard-container");
            cards.forEach((card, index) => {
              setTimeout(() => {
                card.classList.add("card-visible");
              }, index * 150);
            });
          }
        });
      },
      { threshold: 0.2, rootMargin: "0px 0px -50px 0px" }
    );

    if (currentSection) {
      observer.observe(currentSection);
    }

    return () => {
      if (currentSection) {
        observer.unobserve(currentSection);
      }
    };
  }, []);

  const featurescardsdata = [
    {
      icon: <FaUserGraduate size={40} />,
      Title: "هويتك الرقمية",
      subTitel: "ملف شخصي احترافي يعكس هويتك الأكاديمية: اسمك، تخصصك، مهاراتك، اهتماماتك، وروابط تواجدك الرقمي ومعرض أعمالك",
    },
    {
      icon: <FaHandshake size={40} />,
      Title: "نظام الشركاء",
      subTitel: "ينتهي البحث العشوائي، ينشر طلب مشروع ويقترح النظام الطلاب الأكثر توافقاً مع معاييرك، وإشعار فور اكتمال الفريق",
    },
    {
      icon: <FaComments size={40} />,
      Title: "تفاعل هادف",
      subTitel: "مساحة للنقاشات الأكاديمية الجادة، منشورات منظمة، تعليقات مثمرة، ضمن مواضيع تقنية بحت",
    },
    {
      icon: <FaUsers size={40} />,
      Title: "لطلاب التقني",
      subTitel: "لطلاب التخصصات التقنية في الجامعة الافتراضية السورية والخريجين، بيئة تواصل تعطي فائدة حقيقية",
    },
    {
      icon: <FaRocket size={40} />,
      Title: "تطوير الذات",
      subTitel: "زيادة خبرتك العملية، تطوير ذاتك، وتكوين علاقات مع طلاب ناجحين ذوي قيمة في مجالك",
    },
  ];

  return (
    <div className="features-container" ref={sectionRef}>
      <div className="features-content">
        <h2 className="features-title">لماذا Society؟</h2>
        <div className="features-grid">
          {featurescardsdata.map((feature, index) => (
            <FeaturesCard
              key={index}
              icon={feature.icon}
              Title={feature.Title}
              subTitel={feature.subTitel}
            />
          ))}
        </div>
      </div>
    </div>
  );
}