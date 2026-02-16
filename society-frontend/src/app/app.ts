import { Component, signal, OnInit } from '@angular/core';  // ضيف OnInit
import { RouterOutlet } from '@angular/router';
import { Navbar } from './core/layout/navbar/navbar';
import { Footer } from './core/layout/footer/footer';
import * as AOS from 'aos';  // استيراد AOS

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {  // ضيف implements OnInit
  
  protected readonly title = signal('society-frontend');

  ngOnInit() {
    // تهيئة AOS مع إعدادات احترافية
   AOS.init({
  duration: 1000,           // مدة التأثير
  easing: 'ease-in-out',    // نوع الحركة
  once: true,               // 👈 مهم: يظهر مرة واحدة فقط أول مرة توصلها
  mirror: false,            // 👈 ما يشتغل لما ترجع فوق
  offset: 120,              // متى يبدأ (بكسل قبل ما توصل العنصر)
  delay: 0,                 // بدون تأخير زائد
  disable: false,
});

    // تحديث AOS عند تحميل الصفحة
    window.addEventListener('load', () => {
      AOS.refresh();
    });
  }
}