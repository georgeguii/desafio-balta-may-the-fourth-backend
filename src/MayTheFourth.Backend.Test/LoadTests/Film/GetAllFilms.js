import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    stages: [
        { duration: '1m', target: 100 },
        { duration: '3m', target: 100 },
        { duration: '1m', target: 0 },

    ],
    thresholds: {
        checks: ['rate > 0.99'],
        http_req_duration: ['p(95) < 200']
    }
}

export default function () {
    const url = `https://${__ENV.MY_HOSTNAME}/v1/films`;
    const res = http.get(url);

    check(res, {
        'status code 200': (r) => r.status === 200
    });

    sleep(1);
}