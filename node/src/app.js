
//
//     homer - The complete home automation for Homer Simpson.
//     Copyright (C) 2020, Hüseyin Uslu - shalafiraistlin at gmail dot com
//     https://github.com/bonesoul/homer
//
//      “Commons Clause” License Condition v1.0
//
//      The Software is provided to you by the Licensor under the License, as defined below, subject to the following condition.
//
//      Without limiting other conditions in the License, the grant of rights under the License will not include, and the License
//      does not grant to you, the right to Sell the Software.
//
//      For purposes of the foregoing, “Sell” means practicing any or all of the rights granted to you under the License to provide
//      to third parties, for a fee or other consideration (including without limitation fees for hosting or consulting/ support
//      services related to the Software), a product or service whose value derives, entirely or substantially, from the functionality
//      of the Software.Any license notice or attribution required by the License must also include this Commons Clause License
//      Condition notice.
//
//      License: MIT License
//      Licensor: Hüseyin Uslu
'use strict';

require('app-module-path').addPath(__dirname);
const config = require('config');
const os = require('os');
const path = require('path');
const winston = require('winston');
const util = require('util');
const events = require('events');
const emitter = new events.EventEmitter();
const logger = require('lib/logger');
const packageInfo = require('../package.json');

const startup = async () => {
  try {
    // ========================================
    // initialize env manager.
    // ========================================
    require('lib/env');

    // ========================================
    // initialize log manager.
    // ========================================
    await logger.processLogger('homer');

    // ========================================
    // print startup banner.
    // ========================================
    winston.info('      ___  _____						          ');
    winston.info('    .\'/,-Y"     "~-.					        ');
    winston.info('    l.Y             ^.				        ');
    winston.info('    /\               _\_      "Doh!"	');
    winston.info('   i            ___/"   "\			      ');
    winston.info('   |          /"   "\   o !			      ');
    winston.info('   l         ]     o !__./			      ');
    winston.info('    \ _  _    \.___./    "~\			    ');
    winston.info('     X \/ \            ___./			    ');
    winston.info('    ( \ ___.   _..--~~"   ~`-.		    ');
    winston.info('     ` Z,--   /               \		    ');
    winston.info('       \__.  (   /       ______)		  ');
    winston.info('         \   l  /-----~~" /      		  ');
    winston.info('          Y   \          /			      ');
    winston.info('          |    "x______.^				      ');
    winston.info('          |           \\			        ');
    winston.info('          j            Y				      ');
    winston.info('');
    winston.info(`[HOMER] starting up homer version: ${packageInfo.version} [${env}]`); // eslint-disable-line no-undef
    winston.info(`[HOMER] running on: ${os.platform()}-${os.arch()} [${os.type()} ${os.release()}]`);
    winston.info(`[HOMER] node: ${process.versions.node}, v8: ${process.versions.v8}, uv: ${process.versions.uv}, openssl: ${process.versions.openssl}`);
    winston.info(`[HOMER] running over ${os.cpus().length} core system.`);

    // ========================================
    // start homekit support.
    // ========================================
    await require('homekit/homekit')();

    // ========================================
    // add process signal handlers.
    // ========================================
    process.on('SIGTERM', gracefulExit);
    process.on('SIGINT', gracefulExit);

    // ========================================
    // broadcast startup event.
    // ========================================
    winston.info('[HOMER] startup done..');
    emitter.emit('startup');
  } catch (err) {
    winston.error(`startup error: ${err}`);
  }
};

const gracefulExit = code => {
  winston.info(`[HOMER] exiting process with code: ${code}`);
  process.exit(code);
};

process.on('unhandledRejection', (reason, promise) => {
  winston.error(`Possibly unhandled rejection at promise; ${util.inspect(promise)}`);
});

startup();

module.exports = emitter;