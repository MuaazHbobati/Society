import { Component } from '@angular/core';
import { HeroSection } from '../../components/hero-section/hero-section';
import { FeaturesSection } from '../../components/features-section/features-section';
import { HowItWorks} from '../../components/how-it-works/how-it-works';  // 
@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [HeroSection, FeaturesSection, HowItWorks],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePageComponent {

}