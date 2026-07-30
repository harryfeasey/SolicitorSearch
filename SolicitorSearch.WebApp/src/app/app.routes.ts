import { Routes } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { ReportComponent } from './components/report.component/report.component';

export const routes: Routes = [
    {
        path: 'search',
        component: SearchComponent
    },
    {
        path: 'report',
        component: ReportComponent
    },
    {
        path: '',
        component: SearchComponent
    }
];
