'use strict';

const gulp = require('gulp');
const gat = require('gulp-all-tasks')();
const exec = require('child_process').exec;
const opn = require('opn');

const config = {
    repo: 'https://github.com/luminous-software/extensibility-logs.git',
    remote: 'github',
    branch: 'master',
    folder: 'site',
    push: 'false',
    force: 'false',
    user: {
        email: 'yd@live.com.au',
        name: 'Yann Duran'
    },
    address: '127.0.0.1',
    port: '8005'
};

const script = {
    generate: 'mkdocs build',
    serve: 'mkdocs serve --dev-addr=' + config.address + ':' + config.port,

    changes: 'git log -n 1 HEAD --pretty=format:"  * %s"',
    log: 'git log HEAD --pretty=format:"  * %s"'
};

gulp.task('log', function (cb) {
    exec(script.log, function (err, stdout, stderr) {
        gulp_util.log(stdout);
        gulp_util.log(stderr);
        cb(err);
    });
});

gulp.task('changes', function (cb) {
    exec(script.changes, function (err, stdout, stderr) {
        gulp_util.log(stdout);
        gulp_util.log(stderr);
        cb(err);
    });
});

gulp.task('generate', function (cb) {
    exec(script.generate, function (err, stdout, stderr) {
        gulp_util.log(stdout);
        gulp_util.log(stderr);
        cb(err);
    });
});

gulp.task('serve', function (cb) {
    const address = config.address + ':' + config.port;

    gulp_util.log(address);

    exec(script.serve, function (err, stdout, stderr) {
        gulp_util.log(stdout);
        gulp_util.log(stderr);
        cb(err);
    });
    opn('http://' + address);
});

gulp.task('default', ['serve']);
