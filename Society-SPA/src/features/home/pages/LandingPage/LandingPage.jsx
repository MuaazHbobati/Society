import Features from "../../components/Features/Features.jsx";
import HeroSection from "../../components/HeroSection/HeroSection.jsx";
import Statistics from "../../components/Statistics/Statistics.jsx";
import HowToStart from "../../components/HowToStart/HowToStart.jsx";
 
export default function LandingPage() {
  
  return (
    <>
      <HeroSection />

      <Statistics />

      <section id="features">
        <Features />
      </section>
      
      <section id="how-to-start">
        <HowToStart />
      </section>
    
    </>
  );
}