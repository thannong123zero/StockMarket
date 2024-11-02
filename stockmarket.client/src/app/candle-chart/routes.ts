import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./candle-chart.component').then(m => m.CandleChartComponent),
    data: {
      title: $localize`Stock Market`
    }
  }
];

