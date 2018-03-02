import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { BreadCrumb } from './breadcrumb';

@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.scss'],
  encapsulation: ViewEncapsulation.None
})
  //shameless copy from
  //https://github.com/bovandersteene/ngx-breadcrumb
export class BreadcrumbsComponent implements OnInit {
  breadcrumbs$ = this.router.events
    .filter(event => event instanceof NavigationEnd)
    .distinctUntilChanged()
    .map(event => this.buildBreadCrumb(this.activatedRoute.root));
  // Build your breadcrumb starting with the root route of your current activated route

  constructor(private activatedRoute: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
  }

  buildBreadCrumb(route: ActivatedRoute, url: string = '',
    breadcrumbs: Array<BreadCrumb> = []): Array<BreadCrumb> {
    // If no routeConfig is avalailable we are on the root path
    const path = route.routeConfig ? route.routeConfig.path : '';

    const label = route.routeConfig ? route.routeConfig.data['breadcrumb'] : 'Home';

    
    // In the routeConfig the complete path is not available,
    // so we rebuild it each time
    
    const nextUrl = `${url}${path}/`;
    const breadcrumb = {
      label: label,
      url: nextUrl,
      params:''
    };
    const newBreadcrumbs = [...breadcrumbs, breadcrumb];

    if (path == '' && label == '')
      newBreadcrumbs.length = newBreadcrumbs.length - 1;

    if (route.firstChild) {
      // If we are not on our current path yet,
      // there will be more children to look after, to build our breadcumb
      return this.buildBreadCrumb(route.firstChild, nextUrl, newBreadcrumbs);
    }
    return newBreadcrumbs;
  }
}
