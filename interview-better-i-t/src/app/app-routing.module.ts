import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TabelComponent } from './Component/tabel/tabel.component';
import { ChartComponent } from './Component/chart/chart.component';

const routes: Routes = [
  {
    path: "entiters",
    component: TabelComponent
  },
  {
    path: "data-anlytics",
    component: ChartComponent
  }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
