<template>
    <div class="inline-flex" id="tooltipTriggerDiv" @mouseover="isTriggered = true" @mouseout="isTriggered = false">
        <slot name="tooltipTrigger"></slot>
    </div>
    <div>
        <Teleport to="#tooltipTriggerDiv">
            <Transition name="tooltip">
                <slot name="tooltipContent"></slot>
            </Transition>
        </Teleport>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';



const isTriggered = ref(false)

</script>

<style scoped>
.tooltip-enter-active {
    -webkit-animation: scale-in-top .5s cubic-bezier(.25, .46, .45, .94) both;
    animation: scale-in-top .5s cubic-bezier(.25, .46, .45, .94) both
}

/* ----------------------------------------------
 * Generated by Animista on 2023-4-30 14:56:24
 * Licensed under FreeBSD License.
 * See http://animista.net/license for more info. 
 * w: http://animista.net, t: @cssanimista
 * ---------------------------------------------- */

@-webkit-keyframes scale-in-top {
    0% {
        -webkit-transform: scale(0);
        transform: scale(0);
        -webkit-transform-origin: 50% 0;
        transform-origin: 50% 0;
        opacity: 1
    }

    100% {
        -webkit-transform: scale(1);
        transform: scale(1);
        -webkit-transform-origin: 50% 0;
        transform-origin: 50% 0;
        opacity: 1
    }
}

@keyframes scale-in-top {
    0% {
        -webkit-transform: scale(0);
        transform: scale(0);
        -webkit-transform-origin: 50% 0;
        transform-origin: 50% 0;
        opacity: 1
    }

    100% {
        -webkit-transform: scale(1);
        transform: scale(1);
        -webkit-transform-origin: 50% 0;
        transform-origin: 50% 0;
        opacity: 1
    }
}
</style>